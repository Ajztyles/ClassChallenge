using System;

class CountdownTimer
{
    static void Main()
    {
        Console.WriteLine("Simple Countdown Timer!");
        Console.WriteLine("Enter a future time in Hour:Minutes  format (or type 'exit' to quit).");

        while (true)
        {
            Console.Write("\nEnter time (Hour:Minutes ) or 'exit': ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (TimeSpan.TryParse(input, out TimeSpan targetTime))
            {
                DateTime now = DateTime.Now;
                DateTime targetDateTime = now.Date + targetTime; 

                if (targetDateTime < now)
                {
                    Console.WriteLine("That time has already passed.");
                }
                else
                {
                    Console.WriteLine($"Countdown started! Time remaining: {targetDateTime - now}");

                    while (DateTime.Now < targetDateTime)
                    {
                        TimeSpan remaining = targetDateTime - DateTime.Now;
                        Console.Write($"\rTime left: {remaining.Minutes}m {remaining.Seconds}s  ");
                    }

                    Console.WriteLine("\nTime is up!");
                }
            }
            else
            {
                Console.WriteLine("Invalid time format. Please use HH:MM.");
            }
        }
    }
}
