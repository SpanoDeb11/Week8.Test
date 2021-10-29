using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Entities
{
    public enum Role
    {
        Restaurant,
        Client
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
