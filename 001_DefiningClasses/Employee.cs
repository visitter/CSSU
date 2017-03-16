using System;

namespace _001_DefiningClasses
{
    enum CompanyPositions { JUNIOR_DEVELOPER, DEVELOPER, SENIOR_DEVELOPER, SCRUM_MASTER, PRODUCT_OWNER, QA }
    enum CompanyDepartment { DEVELOPMENT, TESTERS, MANAGEMENT }

    class Employee
    {
        private string name;
        private double salary;
        private string email="n/a";
        private int age=-1;

        public string Name { get { return name; } set { if (value.Trim() != "") name = value; } }
        public double Salary { get{ return salary; } set { if (value>0) salary = value; } }
        public CompanyPositions Position { get; set; }
        public CompanyDepartment Department { get; set; }
        public string Email { get { return email; }
            set {
                if (value.Contains("@"))
                    email = value;
            }
        }
        public int Age { get { return age; } set { if (value > 0) age = value; } }

        public Employee(string Name, double Salary, CompanyPositions Position, CompanyDepartment Department, string Email="", int Age=-1)
        {
            this.Name = Name;
            this.Salary = Salary;
            this.Position = Position;
            this.Department = Department;
            this.Email = Email;
            this.Age = Age;
        }

        public override string ToString()
        {
            return String.Format($"Name:{name} {salary} {Position} {Department} {Email} {Age}");
        }
    }
}

//namespace can not begin with a number
/*
namespace 0test
{

}
*/