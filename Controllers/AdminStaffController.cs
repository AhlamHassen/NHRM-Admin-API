using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NHRM_Admin_API.Model;

namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminStaffController : ControllerBase
    {
        private readonly NHRMDBContext context;

        public AdminStaffController(NHRMDBContext _context)
        {
            context = _context;
        }

        //Gets All Patients
        [HttpGet]
        [Route("GetAllStaff")]
        public IEnumerable<staff> GetAllPatients()
        {
            return context.staff.ToList();
        }
    }
}
