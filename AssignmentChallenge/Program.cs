using System;
using System.Text.RegularExpressions;

class Program
{
    static string ReverseDateFormat(string input)
    {
        // Regular expression to match the date format mm/dd/yyyy or m/d/yy
        string pattern = @"^(\d{1,2})/(\d{1,2})/(\d{2,4})$";

        try
        {
            
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
        
                string month = match.Groups[1].Value.PadLeft(2, '0');
                string day = match.Groups[2].Value.PadLeft(2, '0');
                string year = match.Groups[3].Value;

            
                if (year.Length == 2)
                {
                    year = "19" + year;
                }

        
                return $"{year}-{month}-{day}";
            }
            else
            {
                return "Invalid date format!";
            }
        }
        catch
        {
            return "An error occurred while processing the date.";
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Enter a date (mm/dd/yyyy) or 'exit' to quit: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
                break;

            string result = ReverseDateFormat(userInput);
            Console.WriteLine($"Converted Date: {result}\n");
        }
    }
}
