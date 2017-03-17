using System;
using System.Collections.Generic;
using System.Text;

namespace _001_DefiningClasses
{
    //input Model EngineSpeed EnginePower CargoWeight CargoType Tire1Pressure Tire1Age Tire2Pressure Tire2Age Tire3Pressure Tire3Age Tire4Pressure Tire4Age
    class CarEngine
    {
        public int Speed { get; set; }
        public int Power { get; set; }        
    }

    public class Cargo
    {
        public enum CargoType { FRAGILE, FLAMMABLE }
        
        public int Weight { get; set; }
        public CargoType cargoType = CargoType.FRAGILE;
        //public String[] CargoType = new string[]{ "fragile", "flammable" };
    }

    class Tire
    {
        public double TirePreasure { get; set; }
        public int Age { get; set; }
    }

    class CargoCar
    {
        public String Model { get; set; }
        public CarEngine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public bool CheckForLowPreasureTire(int lowPreasure)
        {
            bool FoundLowTire = false;

            foreach( Tire item in Tires)
            {
                if( item.TirePreasure < lowPreasure)
                {
                    FoundLowTire = true;
                    break;
                }
            }

            return FoundLowTire;
        }

        public CargoCar( String Model, int EngineSpeed, int EnginePower, int CargoWeight, Cargo.CargoType CargoType,  double Tire1Pressure, int Tire1Age, double Tire2Pressure, int Tire2Age, double Tire3Pressure, int Tire3Age, double Tire4Pressure, int Tire4Age)
        {
            this.Model = Model;
            Engine = new CarEngine() { Speed = EngineSpeed, Power = EnginePower };
            Cargo = new Cargo() { Weight = CargoWeight, cargoType = CargoType };
            Tires = new Tire[] {
                                new Tire() { TirePreasure=Tire1Pressure, Age=Tire1Age },
                                new Tire() { TirePreasure=Tire2Pressure, Age=Tire2Age },
                                new Tire() { TirePreasure=Tire3Pressure, Age=Tire3Age },
                                new Tire() { TirePreasure=Tire4Pressure, Age=Tire4Age },
                                };
        }

    }
}
