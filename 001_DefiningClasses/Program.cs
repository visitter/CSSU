using System;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

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
            //CarRace();
            //CargoCompany();
            ReadXML();

            Console.ReadLine();
        }
        public static void ReadXML()
        {
            string cXML = @"<contractStatus xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/RESTfulConnector.MyClaimService'>
                                <PropertyChanged xmlns:d2p1 = 'http://schemas.datacontract.org/2004/07/System.ComponentModel' i:nil = 'true' />     
                                <descriptionField>Определяне на дата за сервиз</descriptionField>
                                <iconField>icon-status-wait</iconField>
                                <nameField>Mediator_arranged</nameField>
                                <networkTypeField>EUROHOLD</networkTypeField>
                                <originalNameField>Mediator_arranged</originalNameField>
                                <statusIdField>105981</statusIdField>
                                <statusIdFieldSpecified>true</statusIdFieldSpecified>
                                <statusTypeField>custom</statusTypeField>
                          </contractStatus>";            
            XDocument xml = XDocument.Parse(RemoveAllNamespaces(cXML));
            var var = (xml.Root.Element("originalNameField")?.Value)!=null? xml.Root.Element("originalNameField").Value:null;
            Console.WriteLine(var); 
        }

        //Implemented based on interface, not part of algorithm
        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {   
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                //foreach (XAttribute attribute in xmlDocument.Attributes())
                    //xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
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
        static void CargoCompany()
        {
            Console.WriteLine("Cargo company starting....");
            
            List<CargoCar> list = new List<CargoCar>();

            Console.WriteLine("Enter a car count");
            int count = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Car Info: Model EngineSpeed EnginePower CargoWeight CargoType Tire1Pressure Tire1Age Tire2Pressure Tire2Age Tire3Pressure Tire3Age Tire4Pressure Tire4Age");
                String[] chars = Console.ReadLine().Split(' ');
                list.Add(new CargoCar(
                                        chars[0]
                                        , Int32.Parse(chars[1])
                                        , Int32.Parse(chars[2])
                                        , Int32.Parse(chars[3])
                                        , chars[4]=="fragile"?Cargo.CargoType.FRAGILE: Cargo.CargoType.FLAMMABLE
                                        , Double.Parse(chars[5])
                                        , Int32.Parse(chars[6])
                                        , Double.Parse(chars[7])
                                        , Int32.Parse(chars[8])
                                        , Double.Parse(chars[9])
                                        , Int32.Parse(chars[10])
                                        , Double.Parse(chars[11])
                                        , Int32.Parse(chars[12])));
            }
            Console.WriteLine("cars ok\n");          


            Console.WriteLine("fragile or flammable or end?");
            string command;
            do
            {                
                command = Console.ReadLine();
                switch (command)
                {
                    case "fragile":
                        {
                            foreach (CargoCar item in list)
                            {
                                if (item.CheckForLowPreasureTire(1))
                                {
                                    Console.WriteLine(item.Model);
                                }
                            }
                            break;
                        }
                    case "flammable":
                        {
                            foreach (CargoCar item in list)
                            {
                                if (item.Engine.Power > 250)
                                {
                                    Console.WriteLine(item.Model);
                                }
                            }
                            break;
                        }
                    case "end":break;

                    default:
                        { Console.WriteLine("Invalid command. Type fragile or flammable or end"); break; }
                }
            } while (command != "end");
        }
    }
}