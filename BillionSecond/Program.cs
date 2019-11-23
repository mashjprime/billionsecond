using System;
using System.Collections.Generic;

namespace BillionSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            int birthYear;
            int birthMonth;
            int birthDay;

            birthYear = 1988;
            birthMonth = 6;
            birthDay = 24;

           /* Console.WriteLine("Please enter your birth year:");
            int.TryParse(Console.ReadLine(), out birthYear);
            Console.WriteLine("Please enter your birth month:");
            int.TryParse(Console.ReadLine(), out birthMonth);
            Console.WriteLine("Please enter day of month:");
            int.TryParse(Console.ReadLine(), out birthDay);*/


            DateTime bd = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);
            DateTime billSec = bd.AddSeconds(1000000000);


            TimeSpan span = DateTime.Now.Subtract(billSec);
            Console.WriteLine(span.TotalSeconds);
            Console.WriteLine("Birthday:        " + bd);
            Console.WriteLine("Billion Seconds: " + billSec);

            Console.WriteLine("Days left: " + billSec.Subtract(DateTime.Now).TotalDays);
            Console.WriteLine("Hours left: " + billSec.Subtract(DateTime.Now).TotalHours);
            Console.WriteLine("Minutes left: " + billSec.Subtract(DateTime.Now).TotalMinutes);



            var temp = new List<string> { "Hi", "There" };

            foreach(var word in temp)
            {
                Console.WriteLine(word);
            }
            





            Console.ReadLine();

           /* while (true) {
                Console.Clear();
                Console.WriteLine(countDown());
                Console.WriteLine(DateTime.Now.ToString("h:mmtt d/MM/yyyy"));
                Console.ReadLine(); 
             }*/

        }

        public static double countDown()
        {
            // TimeSpan span = DateTime.Now.Subtract(new DateTime(2020, 1, 1, 0, 0, 0));
            // return span.TotalSeconds;
            return 0.0;
        }

    }
}
