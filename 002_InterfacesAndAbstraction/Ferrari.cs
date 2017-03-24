using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_InterfacesAndAbstraction
{

    class Ferrari : ICar
    {
        string FerrariModel = "488-Spider";
        public string Model { get { return FerrariModel; } }
        public string Driver { get; set; }
        public void HitTheBrake()
        {
            Console.Write("Brakes!");
        }

        public void HitTheGasPedal()
        {
            Console.Write("Zadushavam sA!");
        }
    }

    interface ICar
    {
        void HitTheGasPedal();
        void HitTheBrake();
    }

    interface IAddCollection
    {
        int AddResult { get; set; }
        int Add(string item);
        void PrintOutput();
    }
    interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }   

    class AddCollection:IAddCollection
    {
        protected List<string> list = new List<string>();

        public int AddResult { get; set; }

        public int Add(string item)
        {
            if (list.Count <= 100)
            {
                list.Add(item);
                AddResult = list.IndexOf(item);
                return AddResult;
            }
            else
                return -1;
        }

        public void PrintOutput()
        {
            foreach (var item in list)
            {
                Console.Write(item+" ");
            }
        }
    }

    class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public string Remove()
        {
            if (list.Count > 0)
            {
                string item = list[list.Count - 1];
                list.Remove(item);
                return item;
            }
            else return "Error, there are no items";
        }
    }

    class MyList : AddRemoveCollection
    {
        public int Amount { get { return list.Count; } }
    }

    interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }
        string GetName();
    }

    interface IPerson
    {
        int Name { get; set; }
        int Age { get; set; }
        string GetName();
        int GetNameInt();
    }
    class CitizenR : IResident, IPerson
    {  
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        int IPersonName = 44;
        int IPerson.Name { get { return IPersonName; } set { IPersonName = value; } }

        public int GetNameInt()
        {
            return (this as IPerson).Name;
        }

        string IResident.GetName()
        {
            return "Mr / Ms / Mrs " + Name;
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}
