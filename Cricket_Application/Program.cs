using System;
using System.Collections.Generic;
using Cricket_Application.Models;
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
            if (int.TryParse(Console.ReadLine(), out int totalPlayers) && totalPlayers > 0 && totalPlayers <= 11)
            {
                for (int i = 0; i < totalPlayers; i++)
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
            if (int.TryParse(Console.ReadLine(), out totalPlayers) && totalPlayers > 0 && totalPlayers <= 11)
            {
                for (int i = 0; i < totalPlayers; i++)
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
            var random = new Random();
            // Generate a random number (0 or 1) to simulate a coin toss
            int tossResult = random.Next(2);
            // Determine the result based on the random number
            string result = (tossResult == 0) ? "Bangladesh" : "England";
            int countBang=0;
            int countEng=0;
            int total_run=0;
            int p1_run=0, p2_run=0;
            int total_over = 0;
          
            var EngPlayers = englandTeam.GetPlayers();
            //var totalBangPlayer = bangladeshTeam.GetPlayers().Count();    
            var BangPlayers = bangladeshTeam.GetPlayers();
            do
            {
                Console.WriteLine($"BAN : {total_run}    Over: {total_over}");
                Console.WriteLine($"{BangPlayers[countBang]} : {p1_run}\n{BangPlayers[countBang+1]} : {p2_run}");
                do
                {
                    Console.WriteLine($"England boller Name: {EngPlayers[countEng].Name}");
                    for (int k = 1; k <= 2; k++)
                    {
                       
                        for (int i = 1; i <= 6;)
                        {
                            int run = random.Next(0,10);
                           
                            if(run==1 ||  run==2 || run==3 || run==4 || run == 6)
                            {
                                total_run = total_run + run;
                                i++;
                            }
                            else if (run == 5 || run == 7 || run == 8 || run == 9 || run==10)
                            {
                                if(run == 5)
                                {
                                    Console.WriteLine("No Ball!");
                                    i=i+0;
                                }
                                
                            }
                            else if(run==0)
                            {
                                i++;
                            }
                        }
                    }
                    
                    countEng++;
                } while (countEng <EngPlayers.Count);
                countBang++;
            } while (countBang< BangPlayers.Count);
            Console.WriteLine("Total Run: "+result+" = "+ total_run);
            
            Console.WriteLine("Players in Bangladesh Team:");
            bangladeshTeam.Display();
            Console.WriteLine("Players in England Team:");
            englandTeam.Display();
        }
    }
}
