using System;

namespace QLDH.Entities
{
    [Serializable]
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Quyền hạn (VD: "Admin", "User")

        public Account() 
        { 
        }

        public Account(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
    }
}