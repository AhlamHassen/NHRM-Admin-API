using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHRM_Admin_API.Model;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;



namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly NHRMDBContext context;

        public AdminController(NHRMDBContext _context){
            context = _context;
        }

        //Gets All Patients
        [HttpGet]
        [Route("GetAllPatients")]
        public IEnumerable<Patient> GetAllPatients(){
            return context.Patients.ToList();
        }
        
    }
}