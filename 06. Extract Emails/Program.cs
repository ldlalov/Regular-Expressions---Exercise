using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(?<=\s)([a-z0-9]+[a-z0-9\.\-_]+)@([a-z\-]{2,})(\.[a-z]{2,})+\b");
            MatchCollection emails = regex.Matches(input);
            foreach (Match item in emails)
            {
                Console.WriteLine(item);
            }
        }
    }
}
