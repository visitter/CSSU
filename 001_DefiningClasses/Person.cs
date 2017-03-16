using System;

namespace _001_DefiningClasses
{
    class Person
    {
        public String Name;
        public int Age;

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"I am {Name} and I am {Age} years old");
        }

        public Person(String Name, int Age):this(Age:Age)
        {
            this.Name = Name;         
        }
        
        public Person(int Age) : this()
        {
            this.Age = Age;
        }

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
    }
}
