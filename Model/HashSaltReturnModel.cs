using System;

namespace NHRM_Admin_API.Model
{
    public class HashSaltReturnModel
    {
        public byte[] Password { get; set; }
        public string Salt { get; set; }

        public HashSaltReturnModel(byte[] password, string salt)
        {
            Password = password;
            Salt = salt;
        }
        
    }
}