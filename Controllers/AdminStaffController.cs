
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NHRM_Admin_API.Model;
using NHRM_Admin_API.ViewModels;

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
        public IEnumerable<staff> GetAllStaff()
        {
            return context.staff.ToList();
        }

       // create an endpoint that takes a staff login object and logs in
        [HttpPost]
        [Route("LoginStaff")]
        public ActionResult<StaffLoginResponseModel> Login([FromBody] StaffLoginViewModel staff)
        {
            StaffLoginResponseModel response = new StaffLoginResponseModel();

            var staffList = context.staff.ToList();

            var staffFound = staffList.Find(x => x.Email == staff.email && x.Password == staff.password);
        
            if (staffFound != null)
            {
                //get the role of the staffmember from the 
                var RoleId = context.staff.Where(x => x.Email == staff.email).Select(x => x.RoleId).FirstOrDefault();   
                var RoleName = context.StaffRoles.Where(x => x.RoleId == RoleId).Select(x => x.StaffType).FirstOrDefault();
                response.role = RoleName;
                response.email = staffFound.Email;
                return Ok(response);
            }
            else
            {
                return Unauthorized("Staff Member not found");
            }
            
              
        }

        //create an endpoint that takes a staff object and creates a new staff
        [HttpPost]
        [Route("CreateStaff")]
        public ActionResult<CreateStaffSuccessViewModel> CreateStaff([FromBody] staff staff)
        {
            CreateStaffSuccessViewModel response = new CreateStaffSuccessViewModel();

            var staffList = context.staff.ToList();
            var staffFound = staffList.Find(x => x.StaffId == staff.StaffId);
            if (staffFound != null)
            {
                response.Message = "Staff Member Not Created";
                response.Status = "Failure";
                return BadRequest(response);
            }
            else
            {
                context.staff.Add(staff);
                context.SaveChanges();
                response.Message = "Staff Member Created";
                response.Status = "Success";
                context.Dispose();
                return Ok(response);   
            }
        }


        //create an endpoint that takes a staff object and updates a staff
        [HttpPut]
        [Route("UpdateStaff")]
        public IActionResult UpdateStaff([FromBody] staff staff)
        {
            var staffList = context.staff.ToList();
            var staffFound = staffList.Find(x => x.StaffId == staff.StaffId);
            if (staffFound != null)
            {
                staffFound.StaffId = staff.StaffId;
                staffFound.FirstName = staff.FirstName;
                staffFound.Surname = staff.Surname;
                staffFound.Password = staff.Password;
                staffFound.Email = staff.Email;
                staffFound.RoleId = staff.RoleId;
            }
            else
            {
                return NotFound();
            }
            context.SaveChanges();
            context.Dispose();
            return Ok(staffFound);
        }
    }
}
