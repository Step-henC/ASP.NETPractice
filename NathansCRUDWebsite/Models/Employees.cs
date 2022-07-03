using System;
using System.Text;

namespace NathansCRUDWebsite.Models
{
    public class Employees
    {
        public int EmployeeID {get;set;}

        public string FirstName {get;set;}

        public char MiddleInitial { get;set;}

        public string LastName {get;set;}   

        public string Title { get;set;} 
        public int PhoneNumber { get;set;}

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get;set;}
    }
}
