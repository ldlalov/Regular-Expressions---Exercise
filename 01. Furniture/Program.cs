using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\>>(?<name>[A-Za-z]+)<<(?<price>\d+[.]*\d*)[!](?<quantity>\d+)\b");
            string furniture;
            StringBuilder sb = new StringBuilder();
            while ((furniture = Console.ReadLine()) !="Purchase")
            {
                sb.Append($"{furniture},");
            }
            MatchCollection furnitures = regex.Matches(sb.ToString());
            Console.WriteLine("Bought furniture:");
            decimal sum = 0;
            foreach (Match match in furnitures)
            {
                Console.WriteLine($"{match.Groups["name"].Value}");
                sum += decimal.Parse(match.Groups["price"].Value)*(decimal.Parse(match.Groups["quantity"].Value));
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
