using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHRM_Admin_API.Model;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using NHRM_Admin_API.ViewModels;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Net.Http;
using System.Net;

namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminPatientController : ControllerBase
    {
        private readonly NHRMDBContext context;
        public IConfiguration Configuration { get; }

        public AdminPatientController(NHRMDBContext _context, IConfiguration configuration)
        {
            context = _context;
            Configuration = configuration;
        }


        //Gets All Patients
        [HttpGet]
        [Route("GetAllPatients")]
        public ActionResult<IEnumerable<NewPatientModel>> GetAllPatients()
        {
            // return context.Patients.ToList();
            //TODO -Lee convert to async 
            //TODO -Lee look at limiting the amount of records returned, also use.Select(transofrm to the model).toListAsync to avoid using foreach below 
            var patients = context.Patients.ToList();
            var patientList = new List<NewPatientModel>();

            if (patients == null)
            {
                return NotFound("No patients were found ");
            }

            foreach (var p in patients)
            {
                NewPatientModel patient = new NewPatientModel(
                    p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob, p.Address,
                    p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
                    Convert.ToBase64String(p.Password), p.LivesAlone, p.RegisteredBy, p.Active
                );

                patientList.Add(patient);
            }

            return Ok(patientList);
        }


        //Gets AddPatientModel which includes patient, patientCategories and patientMeasurements using a URNumber 
        [HttpGet]
        [Route("GetPatient")]
        public async Task<ActionResult<AddPatientModel>> GetPatient([FromQuery] string urnumber)
        {
            //TODO -Lee also use.Select(transofrm to the model).toListAsync to avoid using foreach below 
            var p = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == urnumber);

            if (p == null)
            {
                return NotFound("Patient does not exist!");
            }

            NewPatientModel patient = new NewPatientModel(
                p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob, p.Address,
                p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
                Convert.ToBase64String(p.Password), p.LivesAlone, p.RegisteredBy, p.Active
            );

            //If the patient exists then that patient is assigned to atleast 1 patient category b/c when adding a patient,
            //patient category is required
            //TODO -Lee also use.Select(transofrm to the model).toListAsync to avoid using foreach below 
            var pCategories = await context.PatientCategories.Where(p => p.Urnumber == urnumber).ToListAsync();
            var patientCategories = new List<int>();

            foreach (var pc in pCategories)
            {
                patientCategories.Add(pc.CategoryId);
            }

            var pMeasurements = await context.PatientMeasurements.Where(p => p.Urnumber == urnumber).ToListAsync();
            var pMeasurementsList = new List<PatientMeasurementViewModel>();

            //Check if patient measurements exist, this is because you can add a patient and not assign measurements to them
            //TODO -Lee - Ternery operator
            if (pMeasurements != null)
            {
                foreach (var pm in pMeasurements)
                {
                    pMeasurementsList.Add(
                        new PatientMeasurementViewModel(pm.MeasurementId, pm.CategoryId, pm.Frequency)
                     );
                }

                var addPatientModel = new AddPatientModel(patient, patientCategories, pMeasurementsList);
                return Ok(addPatientModel);

            }

            //else if there are no patient measurements
            var addPatientModelNoMeas = new AddPatientModel(patient, patientCategories, null);

            return Ok(addPatientModelNoMeas);
        }


        //adds patient to patient table, patient category and patient measurements
        [HttpPost]
        [Route("AddPatient")]
        public async Task<ActionResult> AddPatient([FromBody] AddPatientModel pm)
        {

            Patient patientExists = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.Patient.Urnumber);

            if (patientExists != null)
            {
                return UnprocessableEntity("Patient already exists");
            }

            if (pm.PatientCategories.Count == 0)
            {
                return UnprocessableEntity("The Patient is not assigned to a patient category");
            }

            var allPatients = await context.Patients.ToListAsync();
            var emailList = new List<string>();

            foreach(var pa in allPatients){
                emailList.Add(pa.Email);
            }

            //To allow only unique emails
            if(emailList.Contains(pm.Patient.Email)){
                return BadRequest("Entered email is already in use");
            }

            HashSaltReturnModel hashsalt = GetPepperedHashSalt(pm.Patient.Password, context, Configuration);
            var p = pm.Patient;

            Patient newPatient = new Patient(p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob,
            p.Address, p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
            hashsalt.Password, hashsalt.Salt, p.LivesAlone, p.RegisteredBy, p.Active);

            context.Patients.Add(newPatient);

            foreach (var c in pm.PatientCategories)
            {
                var patientCategory = new PatientCategory(c, pm.Patient.Urnumber);
                context.PatientCategories.Add(patientCategory);
            }

            if (pm.PatientMeasurements != null)
            {
                foreach (var m in pm.PatientMeasurements)
                {
                    var patientMeasurement = new PatientMeasurement(m.MeasurementId, m.CategoryId, pm.Patient.Urnumber,
                    m.Frequency, DateTime.Now);
                    context.PatientMeasurements.Add(patientMeasurement);
                }
            }

            //TODO -Lee SaveChangesAsync
            context.SaveChanges();
            return Ok(JsonSerializer.Serialize("Patient Added Successfully"));
        }



        [HttpPost]
        [Route("EditPatient")]
        public async Task<ActionResult> EditPatient([FromBody] AddPatientModel pm)
        {

            var patient = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.Patient.Urnumber);
            

            if (patient == null)
            {
                return UnprocessableEntity("The requested patient does not exist");
            }

            var currentEmail = patient.Email;
            var password = patient.Password;
            var salt = patient.Salt;

            if (pm.PatientCategories.Count == 0)
            {
                return UnprocessableEntity("The Patient is not assigned to a patient category");
            }

            var allPatients = await context.Patients.ToListAsync();
            var emailList = new List<string>();

            if(pm.Patient.Email != currentEmail){

                foreach(var pa in allPatients){
                   emailList.Add(pa.Email);
                }

                //To allow only unique emails
                if(emailList.Contains(pm.Patient.Email)){
                    return BadRequest("Entered email is already in use");
                }
            }

            if (pm.Patient.Password != "")
            {

                HashSaltReturnModel hashsalt = GetPepperedHashSalt(pm.Patient.Password, context, Configuration);
                var p = pm.Patient;


                if (patient != null)
                {
                    patient.Urnumber = p.Urnumber;
                    patient.Email = p.Email;
                    patient.Title = p.Title;
                    patient.FirstName = p.FirstName;
                    patient.SurName = p.SurName;
                    patient.Gender = p.Gender;
                    patient.Dob = p.Dob;
                    patient.Address = p.Address;
                    patient.Suburb = p.Suburb;
                    patient.PostCode = p.PostCode;
                    patient.MobileNumber = p.MobileNumber;
                    patient.CountryOfBirth = p.CountryOfBirth;
                    patient.PreferredLanguage = p.PreferredLanguage;
                    patient.Password = hashsalt.Password;
                    patient.Salt = hashsalt.Salt;
                    patient.LivesAlone = p.LivesAlone;
                    patient.RegisteredBy = p.RegisteredBy;
                    patient.Active = p.Active;
                }
            }
            else
            {
                var p = pm.Patient;
                if (patient != null)
                {
                    patient.Urnumber = p.Urnumber;
                    patient.Email = p.Email;
                    patient.Title = p.Title;
                    patient.FirstName = p.FirstName;
                    patient.SurName = p.SurName;
                    patient.Gender = p.Gender;
                    patient.Dob = p.Dob;
                    patient.Address = p.Address;
                    patient.Suburb = p.Suburb;
                    patient.PostCode = p.PostCode;
                    patient.MobileNumber = p.MobileNumber;
                    patient.CountryOfBirth = p.CountryOfBirth;
                    patient.PreferredLanguage = p.PreferredLanguage;
                    patient.LivesAlone = p.LivesAlone;
                    patient.RegisteredBy = p.RegisteredBy;
                    patient.Active = p.Active;
                }

            }


            var pCategories = await context.PatientCategories.Where(p => p.Urnumber == pm.Patient.Urnumber).ToListAsync();
            var pMeasurements = await context.PatientMeasurements.Where(p => p.Urnumber == pm.Patient.Urnumber).ToListAsync();


            //Remove current patient measurements
            foreach (var m in pMeasurements)
            {
                context.PatientMeasurements.Remove(m);
            }

            //Remove current patient categories 
            foreach (var c in pCategories)
            {
                context.PatientCategories.Remove(c);
            }

            //Add new patient categories
            foreach (var c in pm.PatientCategories)
            {
                var patientCategory = new PatientCategory(c, pm.Patient.Urnumber);
                context.PatientCategories.Add(patientCategory);
            }

            //Add new patient measurements
            if (pm.PatientMeasurements != null)
            {
                foreach (var m in pm.PatientMeasurements)
                {
                    var patientMeasurement = new PatientMeasurement(m.MeasurementId, m.CategoryId, pm.Patient.Urnumber,
                    m.Frequency, DateTime.Now);
                    context.PatientMeasurements.Add(patientMeasurement);
                }
            }

            context.SaveChanges();
            return Ok(JsonSerializer.Serialize("Patient was editted successfully"));
        }


        //Search a patient using either a urnumber, givenName or familyName or all
        [HttpGet]
        [Route("SearchPatient")]
        public async Task<ActionResult<IEnumerable<PatientSearchViewModel>>> SearchPatient([FromQuery] string searchurnumber, Boolean isExactUr, string searchgivenname,
            Boolean isExactGivenName, string searchfamilyname, Boolean isExactFamilyName)
        {

            var patientList = new List<PatientSearchViewModel>();
            if (searchurnumber == null && searchgivenname == null && searchfamilyname == null)
            {
                return BadRequest("No search string was provided");
            }

            ///changed the contains to starts with 
            var Qurn = await context.Patients.Where(p => isExactUr ? p.Urnumber == searchurnumber : p.Urnumber.StartsWith(searchurnumber)).ToListAsync();
            var Qgname = await context.Patients.Where(p => isExactGivenName ? p.FirstName == searchgivenname : p.FirstName.StartsWith(searchgivenname)).ToListAsync();
            var Qfname = await context.Patients.Where(p => isExactFamilyName ? p.SurName == searchfamilyname : p.SurName.StartsWith(searchfamilyname)).ToListAsync();

            //intersect to make sure both lists match ¯\_(ツ)_/¯
            if(searchurnumber != null && searchgivenname != null && searchfamilyname == null){
                var output = Qurn.Intersect(Qgname);
                return Ok(output);
            }

            if(searchurnumber != null && searchgivenname == null && searchfamilyname != null){
                var output = Qurn.Intersect(Qfname);
                return Ok(output);
            }

             if(searchurnumber != null && searchgivenname != null && searchfamilyname != null){

                var output = Qurn.Intersect(Qfname).Intersect(Qgname);
                return Ok(output);
            }


            // it the above arent caught it jsut returns one of these and re
            // concat and remove any duplicate values in the final list
            var result = Qurn.Concat(Qgname).Concat(Qfname).Distinct();
         

            return Ok(result);
        }


        // it returns the table data for the view patient mode
        [HttpGet]
        [Route("ViewPatient")]
        public async Task<ActionResult<IEnumerable<ViewTableDataNoUr>>> ViewPatient([FromQuery] String urnumber)
        {

            var result = await context.ViewTableData.Where(p => p.URNumber == urnumber).ToListAsync();

            if (result.Count == 0)
            {
                ///this has been changed to a 204 - no content rather than bad request
                //bad reuest means the url is mal-formed
                // should we return 
                return NoContent();
            }

            List<ViewTableDataNoUr> outputlist = new List<ViewTableDataNoUr>();
            foreach (var m in result)
            {

                var data = new ViewTableDataNoUr(
                    m.DateTimeRecorded.ToString("dd/MM/yyyy"),
                    m.EcogStatus,
                    m.Breathlessness,
                    m.LevelOfPain,
                    m.FluidDrain,
                    m.Mobility,
                    m.SelfCare,
                    m.UsualActivities,
                    m.QolPainDiscomfort,
                    m.AnxietyDepressinon,
                    m.HealthSlider
                );

                outputlist.Add(data);
            }

            return Ok(outputlist);

        }
        

        // it returns the table data for the view patient mode
        [HttpGet]
        [Route("ViewPatientInfo")]
        public async Task<ActionResult<IEnumerable<ViewPatientInfoModel>>> ViewPatientInfo([FromQuery] String urnumber)
        {

            var result = await context.Patients.Where(p => p.Urnumber == urnumber).FirstOrDefaultAsync();

            if (result == null)
            {
                ///this has been changed to a 204 - no content rather than bad request
                //bad reuest means the url is mal-formed
                return NotFound();
            }

            ViewPatientInfoModel patientOutput = new ViewPatientInfoModel(
                result.Urnumber,
                result.Title,
                result.FirstName,
                result.SurName,
                result.Active,
                result.Dob
            );


            return Ok(patientOutput);
        }

        // just checking if authorization would work for patients
        [HttpPost, Route("PatientLogin")]
        public async Task<IActionResult> Login([FromQuery] string email, string password)
        {
            var patient = await context.Patients.Where(p => p.Email == email).Select(p => new Patient
            {
                Urnumber = p.Urnumber,
                Salt = p.Salt,
                Password = p.Password
            }).SingleOrDefaultAsync();

            if (patient != null)
            {
                var passwordHash = SHA512.Create();

                passwordHash.ComputeHash(Encoding.UTF8.GetBytes(password + patient.Salt + Configuration.GetValue<string>("EnvironmentVariables:Pepper")));

                if (passwordHash.Hash.SequenceEqual(patient.Password))
                {
                    return Ok("Success");

                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return NotFound(new { message = "Patient not found" });
            }
        }


        //*************************** STATIC METHODS FOR PASSWORD HASSHING ****************************************************

        //password hashing using hash, salt and pepper. returns password hash and salt string
        public static HashSaltReturnModel GetPepperedHashSalt(string password, NHRMDBContext context, IConfiguration config)
        {
            //Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            string saltString = Convert.ToBase64String(salt);

            //Creates an instance of the default implementation of SHA512
            var passwordHash = SHA512.Create();

            var ad = new AdminPatientController(context, config);

            //password hash 
            byte[] hashedPassword = passwordHash.ComputeHash(Encoding.UTF8.GetBytes(password + saltString + ad.Configuration.GetValue<string>("EnvironmentVariables:Pepper")));

            return new HashSaltReturnModel(hashedPassword, saltString);
        }


        //password hashing using hash and salt only, returns the password hash and salt string
        public static List<string> GetHashandSalt(string password)
        {

            //Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            string saltString = Convert.ToBase64String(salt);

            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashBytesString = Convert.ToBase64String(hashBytes);

            List<string> HashSalt = new List<string>() { hashBytesString, saltString };

            return HashSalt;
        }

    }
}