using KpiNew.Enum;
using System;
using System.Collections.Generic;

namespace KpiNew.Entities

{
    public class Employee : BaseEntity
    {
        public string FirstName {get; set;}
        public string LastName {get;set;}
        public string Email {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string PhoneNumber {get; set;}
        public string EmployeeImage {get; set;} 
        public Gender Gender {get; set;}
        public DateTime DateOfBirth {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public int DepartmentId {get; set;}
        public Department Department {get; set;}
        public ICollection<KpiResult> KpiResults {get; set;} = new List<KpiResult>();



    }
}