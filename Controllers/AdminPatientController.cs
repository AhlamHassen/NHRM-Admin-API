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
        //todo maybe make this a view
        [HttpGet]
        [Route("GetAllPatients")]
        public IEnumerable<Patient> GetAllPatients(){
            return context.Patients.ToList();
        }

        //Gets a Patient using a URNumber -- still needs a bit of work to display categories and measurements
        [HttpGet]
        [Route("GetPatient")]
        public async Task<ActionResult<Patient>> GetPatient([FromQuery] string urnumber){
            Patient patient = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == urnumber);

            if(patient == null){
                return NotFound("Patient does not exist!");
            }

            return Ok(patient);
        }


        //adds patient to patient table, patient category and patient measurements
        [HttpPost]
        [Route("AddPatient")]
        public async Task<ActionResult> AddPatient([FromBody] AddPatientModel pm){

            Patient patientExists = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.patient.Urnumber);
            
            if(patientExists != null){
                return BadRequest("Patient already exists");
            }

            if(pm.patientCategory.Count == 0){
                return BadRequest("The Patient is not assigned to a patient category");
            }
            
            // Create the patient of type Patient from the pm.Patient (which is of type PatientViewModel)

            // option: generate random strings which include symbols, number and minimum length
            List<string> hashsalt = GetHashandSalt(pm.patient.Password);
            var p = pm.patient;

            Patient newPatient = new Patient(p.Urnumber, p.Email, p.Title, p.FirstName, p.SurName, p.Gender, p.Dob,
            p.Address, p.Suburb, p.PostCode, p.MobileNumber, p.HomeNumber, p.CountryOfBirth, p.PreferredLanguage,
            hashsalt[0], hashsalt[1], p.LivesAlone, p.RegisteredBy, p.Active);

            context.Patients.Add(newPatient);
            
            foreach(var c in pm.patientCategory){
                //var pc = new PatientCategory () { CategoryId = c, urNumber = newPatient.urNumber}
                context.PatientCategories.Add(c);
            }

            foreach(var m in pm.patientMeasurement){
                context.PatientMeasurements.Add(m);
            }
 
            context.SaveChanges();
            return Ok("Patient was added successfully");
        }


        [HttpPost]
        [Route("EditPatient")]
        public async Task<ActionResult> EditPatient([FromBody] AddPatientModel pm){

            var patient = await context.Patients.FirstOrDefaultAsync(p => p.Urnumber == pm.patient.Urnumber);
            List<string> hashsalt = GetHashandSalt(pm.patient.Password);
            var p = pm.patient;

            if(pm.patientCategory.Count == 0){
                return BadRequest("The Patient is not assigned to a patient category");
            }

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
                patient.Password = hashsalt[0];
                patient.Salt = hashsalt[1];
                patient.LivesAlone = p.LivesAlone;
                patient.RegisteredBy = p.RegisteredBy;
                patient.Active = p.Active;
            }

            var pCategories = await context.PatientCategories.Where(p => p.Urnumber == pm.patient.Urnumber).ToListAsync();
            var pMeasurements = await context.PatientMeasurements.Where(p => p.Urnumber == pm.patient.Urnumber).ToListAsync();

           
            //Remove current patient measurements
            foreach(var m in pMeasurements){
                context.PatientMeasurements.Remove(m);
            }

            //Remove current patient categories 
            foreach(var c in pCategories){
                context.PatientCategories.Remove(c);
            }

            //Add new patient categories
             foreach(var c in pm.patientCategory){
                context.PatientCategories.Add(c);
            }

            //Add new patient measurements
            foreach(var m in pm.patientMeasurement){
                context.PatientMeasurements.Add(m);
            }

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


        //View Patient
        // [HttpGet]
        // [Route("ViewPatient")]

        
        // we are not deleting patients we will activate and deactivate only
        


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