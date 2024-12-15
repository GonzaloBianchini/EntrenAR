using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Dni {  get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string User {  get; set; }
        public string Password { get; set; }
        



    }
}