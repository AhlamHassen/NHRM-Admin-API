using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class staff
    {
        public staff()
        {
            Patients = new HashSet<Patient>();
            Treatings = new HashSet<Treating>();
        }

        public int StaffId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public byte[] Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }

        public virtual StaffRole Role { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Treating> Treatings { get; set; }
    }
}
