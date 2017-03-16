using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _001_DefiningClasses
{
    class Car
    {
        private static Dictionary<String,Car> Models = new Dictionary<String,Car>();
        
        Double FuelAmount;
        Double FuelP1KM;
        Double DistanceTraveled = 0;

        public static Car GetCarByModel(String Model)
        {
            if (Models.ContainsKey(Model))
                return Models[Model];
            else
                throw new Exception("There is no model with this name");
        }

        public void Drive(double amountOfKM)
        {
            Double maxDistance = FuelAmount / FuelP1KM;
            if (maxDistance >= amountOfKM)
            {
                //Console.WriteLine($"Max distance:{maxDistance}");
                Console.WriteLine($"Driving {amountOfKM}");
                FuelAmount -= FuelP1KM * amountOfKM;
                DistanceTraveled = amountOfKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive!");
            }            
        }
        public override string ToString()
        {
            foreach (var item in Models)
            {
                if( item.Value == this)
                {
                    return String.Format("{0} {1:f} {2}",item.Key,FuelAmount,DistanceTraveled);
                }                    
            }
            return "No items";
            
        }
        public Car( String Model, Double Fuel, Double Fuel1KM)
        {
            if(Models.ContainsKey(Model))
            {
                throw new Exception("The model already exists");
            }
            else
            {
                Models.Add(Model, this);                
                this.FuelAmount = Fuel;
                this.FuelP1KM = Fuel1KM;
            }
        }
        
    }
    /*
    class CarManager
    {
        private static List<Car> Models = new List<Car>();
        public static int Count { get{ return Models.Count; } }

        public object this[int index]
        {
            get { return Models[index]; }
            set
            {
                if (value is Car) {
                    if (Models.Count > index)
                    {
                        Car temp = value as Car;

                        if (!Models.Contains(temp))
                            Models.Add(temp);
                    }
                }
            }
        }
        public void AddCar(Car car)
        {
            foreach (Car item in Models)
            {
                if(item.Model == car.Model)
                    throw new Exception("The model already exists");
            }
            Models.Add(car);
        }
    }
    */
}
