using System;
using System.Collections.Generic;
using Cricket_Application.Models;
using Cricket_Application.Team;
using Cricket_Application.Teams;

namespace Cricket_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            BangladeshTeam bangladeshTeam = new BangladeshTeam();
            EnglandTeam englandTeam = new EnglandTeam();
            string name;
            int age;
            decimal bestscore;
            int ban_total_Players = 0;
            int eng_total_Players = 0;

        Start:
            Console.WriteLine("\n\n\t\t1. Bangladesh  2. England  3. Match Play 0. Cancel");
            Console.WriteLine("\t==================================================================");
            Console.Write("Select option: ");
            int selectCountry = Convert.ToInt32(Console.ReadLine());

            switch (selectCountry)
            {
                case 0:
                    return;
                case 1:
                    goto Bangladesh;
                case 2:
                    goto England;
                case 3:
                    goto GameStart;
                default:
                    Console.WriteLine("Invalid input!");
                    goto Start;
            }

        Bangladesh:
        AddBngPlayer:
            Console.Write("Enter total number of Player (0 < input <= 11): ");
            if (int.TryParse(Console.ReadLine(), out  ban_total_Players) && ban_total_Players > 0 && ban_total_Players <= 11)
            {

                for (int i = 0; i < ban_total_Players; i++)
                {
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Best Score: ");
                    bestscore = Convert.ToDecimal(Console.ReadLine());

                    CricketPlayer player = new CricketPlayer(name, age, bestscore, "Bangladesh");
                    bangladeshTeam.AddPlayer(player);
                }

                goto Start;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number of players.");
                goto AddBngPlayer;
            }

        England:
        AddEngPlayer:
            Console.Write("Enter total number of Player (0 < input <= 11): ");
            if (int.TryParse(Console.ReadLine(), out eng_total_Players) && eng_total_Players > 0 && eng_total_Players <= 11)
            {
                for (int i = 0; i < eng_total_Players; i++)
                {
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Best Score: ");
                    bestscore = Convert.ToDecimal(Console.ReadLine());

                    CricketPlayer player = new CricketPlayer(name, age, bestscore, "England");
                    englandTeam.AddPlayer(player);
                }

                goto Start;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number of players.");
                goto AddEngPlayer;
            }

        GameStart:
            Console.Clear();
            Console.Write("Enter total T20 Match Over of Innings (0 < input <= 20): ");
            int innings_over = Convert.ToInt32(Console.ReadLine());          
            var random = new Random();         
            int tossResult = random.Next(2);

            MatchPlay matchPlay = new MatchPlay(bangladeshTeam, englandTeam,tossResult);
            if (tossResult == 0) {
                matchPlay.FirstInnings(ban_total_Players, innings_over, tossResult);
                matchPlay.SecondInnings(eng_total_Players, innings_over, tossResult);
                matchPlay.Display(tossResult);
            }
            else
            {
                matchPlay.SecondInnings(eng_total_Players, innings_over, tossResult);
                matchPlay.FirstInnings(eng_total_Players, innings_over, tossResult);
                matchPlay.Display(tossResult);
            }
            
        }
    }
}
