using System;

namespace BillionSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Clear();
                Console.WriteLine(countDown());
                Console.ReadLine(); 
             }

        }

        public static double countDown()
        {
            TimeSpan span = DateTime.Now.Subtract(new DateTime(2020, 1, 1, 0, 0, 0));
            return span.TotalSeconds;
        }

    }
}
