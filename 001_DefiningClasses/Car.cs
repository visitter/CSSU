using System;
using System.Collections.Generic;
using System.Linq;

namespace _001_DefiningClasses
{
    class Car
    {
        String Model;
        Double FuelAmount;
        Double FuelP1KM;
        Double DistanceTraveled = 0;

        public void Drive(String carModel, double amountOfKM)
        {
            Double maxDistance = FuelAmount / FuelP1KM;
            if (maxDistance >= amountOfKM)
            {
                FuelAmount -= FuelP1KM * amountOfKM;
            }
            else
            {
                throw new Exception("Insufficient fuel for the drive!");
            }            
        }       
    }
    class CarManager
    {
        private static List<Car> Models = new List<Car>();
        
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
            if (Models.Contains(car))
            {
                Models.Add(car);
            }
            else
                throw new Exception("The model already exists");
        }
    }
}
