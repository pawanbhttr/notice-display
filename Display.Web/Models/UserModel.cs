using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Display.Web.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string UserRole { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool Active { get; set; }
    }
}