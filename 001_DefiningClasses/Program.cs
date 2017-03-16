using System;
using System.Reflection;
using System.Collections.Generic;

namespace _001_DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPerson();
            //CreatePersonObjects();
            //PersonSortedList();
            //ITCompany();
            CarRace();
            Console.ReadLine();
        }

        static void TestPerson()
        {           
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Person contains {0} fields",fields.Length);
                        
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
            bool swapped = false;

            if (nameAgeCtor == null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;            
            }
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;            

            Console.Write("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine(name); ;
            Console.Write("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
            Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { name, age }): (Person)nameAgeCtor.Invoke(new object[] { name, age });
            Console.WriteLine("{0} {1}", basePerson.Name, basePerson.Age);

            Console.WriteLine("{0} {1}", personWithAge.Name, personWithAge.Age);

            Console.WriteLine("{0} {1}", personWithAgeAndName.Name, personWithAgeAndName.Age);
        }

        static void CreatePersonObjects()
        {
            Person p1 = new Person();
            p1.Age = 20;
            p1.Name = "Pesho";

            Person p2 = new Person() { Name = "Gosho", Age = 32 };

            Person p3 = new Person(44);
            p3.DisplayPersonInfo();

            Person p4 = new Person("Ivan", 35);
            p4.DisplayPersonInfo();
        }

        static void PersonSortedList()
        {
            String op = "";

            List<Person> list = new List<Person>();

            while ( op!="q")
            {                
                Console.Write("Enter your name:");
                string name = Console.ReadLine();
                Console.Write("Enter your age:");

                int age=0;
                Int32.TryParse(Console.ReadLine(), out age);
                list.Add(new Person(name,age));

                Console.WriteLine("\"Enter\" for More \"q\" for end");
                op = Console.ReadLine();
            }
            
            //list.Sort(PersonCompare); //-->with method
            //list.Sort( delegate (Person a, Person b) { return a.Name.CompareTo(b.Name); }); //--> with anonymous method
            //list.Sort((a, b) => { return a.Name.CompareTo(b.Name); }); //-->witn Lambda Expression
            list.Sort((a, b) => {
                int res = a.Name.CompareTo(b.Name);
                if (res != 0)
                    return res;
                else
                    return a.Age.CompareTo(b.Age);
            }); //-->wit Lambda Expression compare both fields

            foreach (var item in list){
                if (item.Age > 30) {
                    Console.WriteLine($" Name:{item.Name} Age:{item.Age} ");
                }
            }
        }

        public static int PersonCompare( Person a, Person b)
        {
            int res = a.Name.CompareTo(b.Name);
            if (res != 0)
                return res;
            else
                return a.Age.CompareTo(b.Age);
        }

        public static void ITCompany()
        {
            String op = "";

            List<Employee> list = new List<Employee>();

            while (op != "q")
            {                
                Console.Write("Enter employee name:");
                string name = Console.ReadLine();

                Console.Write("Enter employee salary:");
                double salary;
                Double.TryParse( Console.ReadLine(), out salary);

                Console.Write("Enter employee position:");                
                foreach( var item in Enum.GetValues(typeof(CompanyPositions)))
                {
                    Console.WriteLine($"{(int)item} for {item}");
                }
                int pos;
                Int32.TryParse(Console.ReadLine(), out pos);


                Console.Write("Enter employee department:");
                foreach (var item in Enum.GetValues(typeof(CompanyDepartment)))
                {
                    Console.WriteLine($"{(int)item} for {item}");
                }
                int dep;
                Int32.TryParse(Console.ReadLine(), out dep);

                Console.Write("Enter employee email:");
                string email = Console.ReadLine();                

                Console.Write("Enter you age:");
                int age = -1;
                Int32.TryParse(Console.ReadLine(), out age);
                
                list.Add(new Employee(name,salary,(CompanyPositions)pos,(CompanyDepartment)dep,email,age));

                Console.WriteLine("\"Enter\" for More \"q\" for end");
                op = Console.ReadLine();
            }

            //list.Sort(PersonCompare); //-->with method
            //list.Sort( delegate (Person a, Person b) { return a.Name.CompareTo(b.Name); }); //--> with anonymous method
            //list.Sort((a, b) => { return a.Name.CompareTo(b.Name); }); //-->witn Lambda Expression
            /*
            list.Sort((a, b) => {
                int res = a.Name.CompareTo(b.Name);
                if (res != 0)
                    return res;
                else
                    return a.Age.CompareTo(b.Age);
            }); //-->wit Lambda Expression compare both fields
            */
            SortedList<CompanyDepartment, Double> sl = new SortedList<CompanyDepartment, Double>();

            CompanyDepartment cd = CompanyDepartment.DEVELOPMENT;
            Double max = 0d;
            int counter = 0;
            
            foreach (CompanyDepartment item in Enum.GetValues(typeof(CompanyDepartment)))
            {
                counter = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Department == item)
                    {
                        if (sl.ContainsKey(item))
                        {
                            sl[item] += list[i].Salary;
                        }
                        else
                        {
                            sl.Add(item, list[i].Salary);
                        }
                        counter++;
                    }
                }    

                
                if (sl.ContainsKey(item)) {
                    //calculating average
                    sl[item] = sl[item] / counter;

                    //getting max average and department
                    if (sl[item] > max)
                    {
                        max = sl[item];
                        cd = item;
                    }
                }                
            }

            foreach (var item in list)
            {
                if( item.Department == cd)
                    Console.WriteLine(item);
            }
        }

        
        static void CarRace()
        {
            Console.WriteLine("Car count? =");
            int cars = Int32.Parse(Console.ReadLine());
            List<Car> list = new List<Car>();

            for (int i =0; i<cars; i++)
            {
                Console.WriteLine("Enter car data<Model><Fuel><F1KM>");
                String[] arr = Console.ReadLine().Split(' ');
                try
                {
                    list.Add(new Car(arr[0], Double.Parse(arr[1]), Double.Parse(arr[2])));
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }                
            }

            String[] dArr;
            do
            {
                Console.WriteLine("Enter a car to drive");
                dArr = Console.ReadLine().Split(' ');
                if (dArr[0] == "Drive")
                {
                    Car.GetCarByModel(dArr[1])?.Drive(Double.Parse(dArr[2]));
                }

            } while (dArr[0] != "End");
           
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}