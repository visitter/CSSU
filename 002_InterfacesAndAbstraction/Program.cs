using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _002_InterfacesAndAbstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            CitizenR cit = new CitizenR() { Name = "Pesho", Age = 35, Country = "Bulgaria" };
            Console.WriteLine((cit as IPerson).GetName());
            Console.WriteLine((cit as IResident).GetName());
            Console.WriteLine((cit as IPerson).GetNameInt());

            //CheckCollections();
            //CheckFerrari();
            Console.ReadLine();
        }
        static void CheckCollections()
        {
            Console.WriteLine("Enter strings");
            string[] strings = Console.ReadLine().Split(' ');

            AddCollection addColl = new AddCollection();
            AddRemoveCollection addRemoveColl = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in strings)
            {
                Console.Write( addColl.Add(item));
                addRemoveColl.Add(item);
                myList.Add(item);
            }

            Console.WriteLine("Enter remove items count");
            int removeItems = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < removeItems; i++)
            {                
                addRemoveColl.Remove();
                myList.Remove();
            }
            
        }


        static void CheckFerrari()
        {
            Ferrari car1 = new Ferrari() { Driver = Console.ReadLine() };
            Ferrari car2 = new Ferrari() { Driver = Console.ReadLine() };

            Console.Write(car1.Model);
            car1.HitTheBrake();            
            car1.HitTheGasPedal();
            Console.WriteLine(car1.Driver);

            Console.Write(car2.Model);
            car2.HitTheBrake();
            car2.HitTheGasPedal();
            Console.WriteLine(car2.Driver);

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;

            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }


        static void CheckCitizen()
        {
            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");

            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");

            PropertyInfo[] properties = identifiableInterface.GetProperties();

            Console.WriteLine(properties.Length);

            Console.WriteLine(properties[0].PropertyType.Name);

            properties = birthableInterface.GetProperties();

            Console.WriteLine(properties.Length);

            Console.WriteLine(properties[0].PropertyType.Name);

            string name = Console.ReadLine();

            int age = int.Parse(Console.ReadLine());

            string id = Console.ReadLine();

            string birthdate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);

            IBirthable birthable = new Citizen(name, age, id, birthdate);
        }
    }
}
