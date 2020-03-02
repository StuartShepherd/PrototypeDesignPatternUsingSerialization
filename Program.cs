using System;
using PrototypeUsingSerialization.Prototype;

namespace PrototypeUsingSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype using serialization example");
            Console.WriteLine("Prototype is a creational design pattern that allows cloning objects, even complex ones, without coupling to their specific classes.");
            Console.WriteLine();

            Person person1 = new Person
            {
                Age = 43,
                BirthDate = Convert.ToDateTime("1976-01-01"),
                Name = "Stuart Shepherd",
                IdInfo = new IdInfo(666)
            };

            // make a deep copy of person1 and assign it to person2.
            Person person2 = person1.DeepCopy();

            // display values of person1 and person2.
            Console.WriteLine("Original values of person1 and person2");
            Console.WriteLine("   person1 instance values: ");
            DisplayValues(person1);
            Console.WriteLine("   person2 instance values:");
            DisplayValues(person2);

            // change the value of person1 properties and display the values of person1 and person2.
            person1.Age = 20;
            person1.BirthDate = Convert.ToDateTime("2000-01-01");
            person1.Name = "John";
            person1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of person1 and person2 after changes to person1:");
            Console.WriteLine("   person1 instance values: ");
            DisplayValues(person1);
            Console.WriteLine("   person2 instance values:");
            DisplayValues(person2);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}", p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}