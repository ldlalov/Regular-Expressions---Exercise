using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%(?<custumer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>(\D*)\|(?<count>\d+)\|\D*(?<price>[\d]+[.]*[\d]*)\$");
            Regex regex2 = new Regex(@"(?<price>\d+[.]*\d*)\$");
            string input;
            decimal income = 0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                MatchCollection sales = regex.Matches(input);
                foreach (Match m in sales)
                {
                    var custumer = m.Groups["custumer"].Value;
                    var product = m.Groups["product"].Value;
                    var count = m.Groups["count"].Value;
                    var price = m.Groups["price"].Value;
                    if (custumer != "" && product != "" && count != "" && price != "")
                    {
                        decimal totalPrice = int.Parse(count) * decimal.Parse(price);
                        Console.WriteLine($"{custumer}: {product} - {totalPrice:f2}");
                        income += totalPrice;
                    }
                }
            }
                Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
