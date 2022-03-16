﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ");
            string input;
            Dictionary<string, int> playersList = new Dictionary<string, int>();
            while ((input = Console.ReadLine()) != "end of race")
            {
                string currentParticipant = "";
                int totalDistance = 0;

                Regex regex1 = new Regex(@"([\d])");
                MatchCollection distances = regex1.Matches(input);
                foreach (var participant in participants)
                {
                    if (input.Contains(participant[0]))
                    {
                        currentParticipant = participant;
                        foreach (Match match in distances)
                        {
                            totalDistance += int.Parse(match.Value);
                        }
                        if (!playersList.ContainsKey(currentParticipant))
                        {
                        playersList.Add(currentParticipant, totalDistance);
                        }
                        else
                        {
                            playersList[currentParticipant] += totalDistance;
                        }
                        break;
                    }
                }
            }
            int count = 1;
            var ordered = playersList.OrderByDescending(x => x.Value).Take(3);
            foreach (var item in ordered)
            {
                    if (count == 1)
                    {
                        Console.WriteLine($"{count}st place: {item.Key}");
                    }
                    else if (count == 2)
                    {
                        Console.WriteLine($"{count}nd place: {item.Key}");
                    }
                else if (count == 3)
                    {
                        Console.WriteLine($"{count}rd place: {item.Key}");
                    }
                count++;
            }
        }
    }
}
