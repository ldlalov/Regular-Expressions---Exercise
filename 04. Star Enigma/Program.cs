using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> attackedNames = new List<string>();
            List<string> destroyedNames = new List<string>();
            int attacked = 0;
            int destroyed = 0;
            for (int i = 0; i < count; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(@"[STARstar]");
                MatchCollection matches = regex.Matches(message);
                StringBuilder decoded = new StringBuilder();
                int sum = 0;
                foreach (Match match in matches)
                {
                    sum++;
                }
                foreach (char ch in message)
                {
                    decoded.Append((char)(ch - sum));
                }
                Regex regex1 = new Regex(@"@(?<planet>[A-Za-z]+)[^\@,!:>]*[\-]*:(?<population>\d+)[^\@,!:>]*[\-]*!(?<attakType>[AD])![^\@,!:>]*[\-]*->(?<soldiers>\d+)");
                MatchCollection matches1 = regex1.Matches(decoded.ToString());
                foreach (Match item in matches1)
                {
                    string name = item.Groups["planet"].Value;
                    int population = int.Parse(item.Groups["population"].Value);
                    string attakType = item.Groups["attakType"].Value;
                    int soldiers = int.Parse(item.Groups["soldiers"].Value);
                    if (attakType == "A")
                    {
                        attacked++;
                        attackedNames.Add(name);
                    }
                    if (attakType == "D")
                    {
                        destroyed++;
                        destroyedNames.Add(name);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked}");
            foreach (var item in attackedNames.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed}");
            foreach (var item in destroyedNames.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
