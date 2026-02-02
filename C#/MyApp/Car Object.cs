using System;

namespace MyApp
{
    class Car
    {
        // Properties
        public string Model;
        public string Color;
        public int Year; 

        // Constructor
        public Car(string model, string color, int year)
        {
           Model = model;
           Color = color;
           Year = year ;
        }

        // Method
        public void Main(string[] args)
        {
            Car myCar = new Car("Toyota", "Red", 2020);
            Console.WriteLine($"My car is a {myCar.Color} {myCar.Model} from {myCar.Year}.");
        }

    }
}
