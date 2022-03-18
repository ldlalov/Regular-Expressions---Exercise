using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex0 = new Regex(@"[^, ]+");
            MatchCollection demon = regex0.Matches(input);
            foreach (Match item in demon.OrderBy(x => x.Value))
            {
                int healt = 0;
                double damage = 0;
                Regex regex = new Regex(@"(?<healt>[^0-9.+\-*\/.])");
                MatchCollection healts = regex.Matches(item.ToString());
                Regex regex1 = new Regex(@"(?<damage>-?\d+(?:\.\d+)?)");
                MatchCollection damages = regex1.Matches(item.ToString());
                Regex regex2 = new Regex(@"[*\/]");
                MatchCollection multiply = regex2.Matches(item.ToString());
                foreach (Match h in healts)
                {
                    healt += char.Parse(h.Value);
                }
                foreach (Match match in damages)
                {
                    damage += double.Parse(match.Groups["damage"].Value);
                }
                foreach (Match match1 in multiply)
                {
                    if (match1.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (match1.Value == "/")
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{item} - {healt} health, {damage:f2} damage");
            }
        }
    }
}
