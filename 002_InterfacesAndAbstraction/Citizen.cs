using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_InterfacesAndAbstraction
{
    class Citizen : IPerson1,IIdentifiable,IBirthable
    {
        string FName;
        int FAge;

        public string Name { get { return FName; } set { if (value != "") FName = value; }  }
        public int Age { get { return FAge; } set { if (value > 0) FAge = value; } }

        public string ID { get; set; }
        public string BirthDate { get; set; }

        public Citizen(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public Citizen(string Name, int Age, string Id, string BirthDate):this(Name,Age)
        {
            this.ID = Id;
            this.BirthDate = BirthDate;
        }
    }


    interface IIdentifiable
    {
        string ID { get; set; }
    }
    interface IBirthable
    {
        string BirthDate { get; set; }
    }

    interface IPerson1
    {
        String Name { get; set; }
        int Age { get; set; }
    }
}
