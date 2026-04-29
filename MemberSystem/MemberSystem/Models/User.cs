using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Account { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public int RoleID { get; set; }
    }
}