using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Cricket_Application.Models;
using Cricket_Application.Team;
using Cricket_Application.Teams;

namespace Cricket_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstTeam firstTeam = new FirstTeam();
            SecondTeam secondTeam = new SecondTeam();
            string? firstTeamName = string.Empty, secondTeamName = string.Empty, name = string.Empty,title = string.Empty;
            int age, firstTeamTotalPlayers = 0, secondTeamTotalPlayers = 0, selectOption;
            double bestscore;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Bat  icon emoji \uD83C\uDFCF
            //ball icon emoji \u26BD
            Console.WriteLine("\n\n\t\t\t\t \u2764\uFE0FCricket ODI Tournament\u2764\uFE0F \n\n");
        Start:
            Console.WriteLine("\n\n\t\t1. First Team  2. Second Team  3. Match Play 0. Cancel");
            Console.WriteLine("\t==================================================================");
            Console.Write("Select option: ");
            if (int.TryParse(Console.ReadLine(), out selectOption))
            {
                switch (selectOption)
                {
                    case 0:
                        return;
                    case 1:
                        goto FirstTeam;
                    case 2:
                        goto SecondTeam;
                    case 3:
                        goto GameStart;
                    default:
                        Console.WriteLine("Invalid input!");
                        goto Start;
                }
            }
            else
            {
                goto Start;
            }
        FirstTeam:
        AddBngPlayer:
            Console.Write("Enter FirstTeam Name: ");
            firstTeamName = Console.ReadLine();
            Console.Write("Enter total number of Player (0 < input <= 11): ");
            if (int.TryParse(Console.ReadLine(), out firstTeamTotalPlayers) && firstTeamTotalPlayers > 0 && firstTeamTotalPlayers <= 11)
            {
                Console.WriteLine($"{firstTeamName} Player Details: ");
                for (int i = 0; i < firstTeamTotalPlayers; i++)
                {

                    Console.Write("Name: ");
                    name = Console.ReadLine();
                FTPlayerAge:
                    Console.Write("Age: ");
                    string? playerAge = Console.ReadLine();
                    if (int.TryParse(playerAge, out age)) { }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        goto FTPlayerAge;
                    }
                FTPlayerBestScore:
                    Console.Write("Best Score: ");
                    string? playerBestScore = Console.ReadLine();
                    if (double.TryParse(playerBestScore, out bestscore)) { }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        goto FTPlayerBestScore;
                    }
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    CricketPlayer player = new CricketPlayer(name, age, bestscore, title, firstTeamName);
                    firstTeam.AddPlayer(player);
                }

                goto Start;
            }
            else
            {
                Console.WriteLine("Invalid input!");
                goto AddBngPlayer;
            }

        SecondTeam:
        AddEngPlayer:
            Console.Write("Enter FirstTeam Name: ");
            secondTeamName = Console.ReadLine();
            Console.Write("Enter total number of Player (0 < input <= 11): ");
            if (int.TryParse(Console.ReadLine(), out secondTeamTotalPlayers) && secondTeamTotalPlayers > 0 && secondTeamTotalPlayers <= 11)
            {
                Console.WriteLine($"{secondTeamName} Player Details: ");
                for (int i = 0; i < secondTeamTotalPlayers; i++)
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                STPlayerAge:
                    Console.Write("Age: ");
                    string? playerAge = Console.ReadLine();
                    if (int.TryParse(playerAge, out age)) { }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        goto STPlayerAge;
                    }
                STPlayerBestScore:
                    Console.Write("Best Score: ");
                    string? playerBestScore = Console.ReadLine();
                    if (double.TryParse(playerBestScore, out bestscore)) { }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        goto STPlayerBestScore;
                    }

                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    CricketPlayer player = new CricketPlayer(name, age, bestscore, title, secondTeamName);
                    secondTeam.AddPlayer(player);
                }

                goto Start;
            }
            else
            {
                Console.WriteLine("Invalid input!");
                goto AddEngPlayer;
            }

        GameStart:
            Console.Clear();

        TeamInningsOver:
            Console.Write("Enter total ODI Match Over of Innings (0 < input <= 50): ");
            int inningsOver;
            if (int.TryParse(Console.ReadLine(), out inningsOver))
            {
                var random = new Random();
                int tossResult = random.Next(2);

                MatchPlay matchPlay = new MatchPlay(firstTeam, secondTeam, tossResult, firstTeamName, secondTeamName);
                if (tossResult == 0)
                {
                    matchPlay.FirstInnings(firstTeamTotalPlayers, inningsOver, tossResult, 0, firstTeamName, secondTeamName);
                    matchPlay.SecondInnings(secondTeamTotalPlayers, inningsOver, tossResult, 1, firstTeamName, secondTeamName);
                    matchPlay.Display(tossResult, firstTeamName, secondTeamName);
                }
                else
                {
                    matchPlay.SecondInnings(secondTeamTotalPlayers, inningsOver, tossResult, 1, firstTeamName, secondTeamName);
                    matchPlay.FirstInnings(firstTeamTotalPlayers, inningsOver, tossResult, 0, firstTeamName, secondTeamName);
                    matchPlay.Display(tossResult, firstTeamName, secondTeamName);
                }

            }
            else
            {
                Console.WriteLine("Invalid input!");
                goto TeamInningsOver;
            }
        }
    }
}
