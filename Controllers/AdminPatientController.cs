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


namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminPatientController : ControllerBase
    {
        private readonly NHRMDBContext context;

        public AdminPatientController(NHRMDBContext _context){
            context = _context;
        }

        //Gets All Patients
        [HttpGet]
        [Route("GetAllPatients")]
        public ActionResult<IEnumerable<NewPatientModel>> GetAllPatients(){
            // return context.Patients.ToList();
            var patients = context.Patients.ToList();
            var patientList = new List<NewPatientModel>();

            if(patients == null){
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
        public async Task<ActionResult<AddPatientModel>> GetPatient([FromQuery] string urnumber){
            var p = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == urnumber);
            
            if(p == null){
                return NotFound("Patient does not exist!");
            }

            NewPatientModel patient = new NewPatientModel(
                p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob, p.Address,
                p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
                Convert.ToBase64String(p.Password), p.LivesAlone, p.RegisteredBy, p.Active 
            );

            //If the patient exists then that patient is assigned to atleast 1 patient category b/c when adding a patient,
            //patient category is required

            var pCategories = await context.PatientCategories.Where(p => p.Urnumber == urnumber).ToListAsync();
            var patientCategories = new List<int>();

            foreach (var pc in pCategories)
            {
                patientCategories.Add(pc.CategoryId);
            }

            var pMeasurements = await context.PatientMeasurements.Where(p => p.Urnumber == urnumber).ToListAsync();
            var pMeasurementsList = new List<PatientMeasurementViewModel>();

            //Check if patient measurements exist, this is because you can add a patient and not assign measurements to them
            if(pMeasurements != null){
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
        public async Task<ActionResult> AddPatient([FromBody] AddPatientModel pm){

            Patient patientExists = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.Patient.Urnumber);
            
            if(patientExists != null){
                return BadRequest("Patient already exists");
            }

            if(pm.PatientCategories.Count == 0){
                return BadRequest("The Patient is not assigned to a patient category");
            }
            

            HashSaltReturnModel hashsalt = GetPepperedHashSalt(pm.Patient.Password);
            var p = pm.Patient;

            Patient newPatient = new Patient(p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob,
            p.Address, p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
            hashsalt.Password, hashsalt.Salt, p.LivesAlone, p.RegisteredBy, p.Active);

            context.Patients.Add(newPatient);
            
            foreach(var c in pm.PatientCategories){
                var patientCategory = new PatientCategory(c, pm.Patient.Urnumber);
                context.PatientCategories.Add(patientCategory);
            }

            foreach(var m in pm.PatientMeasurements){
                var patientMeasurement = new PatientMeasurement(m.MeasurementId, m.CategoryId, pm.Patient.Urnumber,
                m.Frequency, DateTime.Now);
                context.PatientMeasurements.Add(patientMeasurement);
            }
 
            context.SaveChanges();
            return Ok("Patient was added successfully");
        }


        ///********************************* NOT DONE **********************************************************
        //if we will enable password edit in the edit mode, will the actuall password will be shown? 
        //what password return is needed?
        [HttpPost]
        [Route("EditPatient")]
        public async Task<ActionResult> EditPatient([FromBody] AddPatientModel pm){

            var patient = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.Patient.Urnumber);
            // List<string> hashsalt = GetHashandSalt(pm.patient.Password);
            var p = pm.Patient;

            // if(pm.patientCategory.Count == 0){
            //     return BadRequest("The Patient is not assigned to a patient category");
            // }

            if(patient != null){
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
                // patient.Password = hashsalt[0];
                // patient.Salt = hashsalt[1];
                patient.LivesAlone = p.LivesAlone;
                patient.RegisteredBy = p.RegisteredBy;
                patient.Active = p.Active;
            }

            var pCategories = await context.PatientCategories.Where(p => p.Urnumber == pm.Patient.Urnumber).ToListAsync();
            var pMeasurements = await context.PatientMeasurements.Where(p => p.Urnumber == pm.Patient.Urnumber).ToListAsync();

           
            //Remove current patient measurements
            foreach(var m in pMeasurements){
                context.PatientMeasurements.Remove(m);
            }

            //Remove current patient categories 
            foreach(var c in pCategories){
                context.PatientCategories.Remove(c);
            }

            // //Add new patient categories
            //  foreach(var c in pm.patientCategory){
            //     context.PatientCategories.Add(c);
            // }

            // //Add new patient measurements
            // foreach(var m in pm.patientMeasurement){
            //     context.PatientMeasurements.Add(m);
            // }

            context.SaveChanges();
            return Ok("Patient was editted successfully");
        }


        //Search a patient using either a urnumber, given name or family name or all
        [HttpGet]
        [Route("SearchPatient")]
        public async Task<ActionResult<IEnumerable<Patient>>> SearchPatient([FromQuery] string searchurnumber, Boolean isExactUr, string searchgivenname,
            Boolean isExactGivenName, string searchfamilyname, Boolean isExactFamilyName){
            
            if(searchurnumber == null && searchgivenname == null && searchfamilyname ==null){
                return BadRequest("No search string was provided");
            }
            //

            var Qurn = isExactUr == true? searchurnumber : searchurnumber+"%";
            var Qgname = isExactGivenName == true ? searchgivenname : searchgivenname+"%";
            var Qfname = isExactFamilyName == true ? searchfamilyname : searchfamilyname+"%";
            
            var result = await context.Patients.Where(p => EF.Functions.Like(p.Urnumber, $"{Qurn}") ||
                EF.Functions.Like(p.FirstName, $"{Qgname}") ||
                EF.Functions.Like(p.SurName, $"{Qfname}")).ToListAsync();

            //-------------------------------------------------------------------------------------------
            // TODO --Hey Ahlam maybe we can use something like this to limit passing the DB whole entity
            //--------------------------------------------------------------------------------------------
            // var result = await context.Patients.Where(p => EF.Functions.Like(p.Urnumber, $"{Qurn}") ||
            //     EF.Functions.Like(p.FirstName, $"{Qgname}") ||
            //     EF.Functions.Like(p.SurName, $"{Qfname}")).Select( x => new PatientSearchViewModel{ 
            //     Urnumber = x.Urnumber, FirstName = x.FirstName, SurName = x.SurName}).ToListAsync(); 
            //   
            //----------------------------- this is not tested yet--------------------------------------

            return Ok(result);
        }


        // it returns the table data for the view patient mode
        [HttpGet]
        [Route("ViewPatient")]
        public async Task<ActionResult<IEnumerable<ViewTableData>>> ViewPatient([FromQuery] String urnumber){
            var result = await context.ViewTableData.Where(p => p.URNumber == urnumber).ToListAsync();
            if(result == null){
                return NotFound("Patient has no recorded measurements");
            }

            return Ok(result);
        }



        //*************************** STATIC METHODS FOR PASSWORD HASSHING ****************************************************

        //password hashing using hash, salt and pepper. returns password hash and salt string
        public static HashSaltReturnModel GetPepperedHashSalt(string password){
            //Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            string saltString = Convert.ToBase64String(salt);

            //Creates an instance of the default implementation of SHA512
            var passwordHash = SHA512.Create();

            //password hash 
            byte[] hashedPassword = passwordHash.ComputeHash(Encoding.UTF8.GetBytes(password + saltString + Environment.GetEnvironmentVariable("Pepper")));
            
            return new HashSaltReturnModel(hashedPassword, saltString);
        }


        //password hashing using hash and salt only, returns the password hash and salt string
        public static List<string> GetHashandSalt(string password){

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

            List<string> HashSalt = new List<string>(){hashBytesString, saltString};

            return HashSalt;
        }
        
    }
}