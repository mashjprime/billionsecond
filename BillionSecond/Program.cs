﻿using System;

namespace BillionSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            int birthYear;
            int birthMonth;
            int birthDay;

            Console.WriteLine("Please enter your birth year:");
            int.TryParse(Console.ReadLine(), out birthYear);
            Console.WriteLine("Please enter your birth month:");
            int.TryParse(Console.ReadLine(), out birthMonth);
            Console.WriteLine("Please enter day of month:");
            int.TryParse(Console.ReadLine(), out birthDay);

            DateTime bd = new DateTime(birthYear, birthMonth, birthDay, 0, 0, 0);
            DateTime billSec = bd.AddSeconds(1000000000);


            TimeSpan span = DateTime.Now.Subtract(billSec);
            Console.WriteLine(span.TotalSeconds);
            Console.WriteLine("Birthday:        " + bd);
            Console.WriteLine("Billion Seconds: " + billSec);

           


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
