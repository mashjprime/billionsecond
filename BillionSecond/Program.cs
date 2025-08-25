using System;
using System.Threading;

namespace BillionSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthDate = ReadBirthDate();
            DateTime now = DateTime.Now;
            TimeSpan age = now.Subtract(birthDate);

            Console.WriteLine();
            Console.WriteLine($"Birthday:        {birthDate:d}");
            Console.WriteLine("You are:");
            Console.WriteLine($"  {age.TotalSeconds:N0} seconds old");
            Console.WriteLine($"  {age.TotalMinutes:N0} minutes old");
            Console.WriteLine($"  {age.TotalHours:N0} hours old");
            Console.WriteLine($"  {age.TotalDays:N0} days old");
            Console.WriteLine($"  {age.TotalDays / 7:N0} weeks old");
            int monthsOld = (now.Year - birthDate.Year) * 12 + now.Month - birthDate.Month;
            if (now.Day < birthDate.Day)
            {
                monthsOld--;
            }
            Console.WriteLine($"  {monthsOld} months old");
            Console.WriteLine($"  {age.TotalDays / 365.25:F2} years old");
            Console.WriteLine($"  {age.TotalDays / 365.25 * 7:F2} dog years old");
            const int beatsPerMinute = 75;
            Console.WriteLine($"  {age.TotalMinutes * beatsPerMinute:N0} heartbeats (at {beatsPerMinute} bpm)");

            const double billionSeconds = 1000000000d;
            DateTime billSec = birthDate.AddSeconds(billionSeconds);
            TimeSpan untilBill = billSec - now;
            Console.WriteLine();
            Console.WriteLine("Billion Seconds: " + billSec);
            if (untilBill.TotalSeconds > 0)
            {
                Console.WriteLine("Time until 1 billion seconds:");
                DisplayCountdown(billSec);
            }
            else
            {
                Console.WriteLine($"You passed the billion second mark {FormatSpan(-untilBill)} ago!");
            }

            const int lifeExpectancyYears = 79;
            DateTime expectedEnd = birthDate.AddYears(lifeExpectancyYears);
            TimeSpan lifeLeft = expectedEnd - now;
            Console.WriteLine();
            Console.WriteLine($"Estimated end of life ({lifeExpectancyYears} yrs): {expectedEnd:d}");
            if (lifeLeft.TotalSeconds > 0)
            {
                Console.WriteLine($"Years left: {lifeLeft.TotalDays / 365.25:F1}");
                Console.WriteLine($"Months left: {lifeLeft.TotalDays / 30.4375:N0}");
                Console.WriteLine($"Weeks left: {lifeLeft.TotalDays / 7:N0}");
                Console.WriteLine($"Days left: {lifeLeft.TotalDays:N0}");
            }
            else
            {
                Console.WriteLine("You've already outlived the average life expectancy!");
            }
            Console.WriteLine($"You have lived {age.TotalDays / (lifeExpectancyYears * 365.25):P2} of your expected lifespan.");

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        static DateTime ReadBirthDate()
        {
            while (true)
            {
                Console.WriteLine("Enter your birthdate (YYYY-MM-DD):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate.Date;
                }
                Console.WriteLine("Invalid date. Please try again.");
            }
        }

        public static string FormatSpan(TimeSpan span)
        {
            span = span.Duration();
            return $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds";
        }

        static void DisplayCountdown(DateTime target)
        {
            const int maxUpdates = 5;
            for (int i = 0; i < maxUpdates; i++)
            {
                TimeSpan remaining = target - DateTime.Now;
                if (remaining.TotalSeconds <= 0)
                {
                    Console.WriteLine("Reached 1 billion seconds!");
                    return;
                }
                Console.Write("\r" + FormatSpan(remaining) + " remaining   ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}

