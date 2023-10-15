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
            var runList = new List<int>() { 0,1,2,4,3,6,5, 0,7, 1, 2, 4, 3, 6 , 0, 1, 2, 4, 3, 6 ,5, 0, 1,8, 2, 4, 3, 6 , 0, 1, 2, 4,9, 3, 6 ,5,5,6,0,2,1,3,4};

            // Generate a random number (0 or 1) to simulate a coin toss
            int tossResult = random.Next(2);
            // Determine the result based on the random number
            string result = (tossResult == 0) ? "Bangladesh" : "England";
            int countBang=0;
            int countEng=0;
            int sum=0;
          
            var EngPlayers = englandTeam.GetPlayers();
            //var totalBangPlayer = bangladeshTeam.GetPlayers().Count();
            var BangPlayers = bangladeshTeam.GetPlayers();
            do
            {
                do
                {
                    Console.WriteLine($"England boller Name: {EngPlayers[countEng].Name}");
                    for (int k = 1; k <= 2; k++)
                    {
                       
                        for (int i = 1; i <= 6; i++)
                        {
                            int index = random.Next(runList.Count);
                            int run = runList[index];
                            if(run==1 ||  run==2 || run==3 || run==4 || run == 6)
                            {
                                sum=sum+run;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    
                    countEng++;
                } while (countEng <EngPlayers.Count);
                countBang++;
            } while (countBang< BangPlayers.Count);
            Console.WriteLine("Total Run: "+result+" = "+sum);
            
            Console.WriteLine("Players in Bangladesh Team:");
            bangladeshTeam.Display();
            Console.WriteLine("Players in England Team:");
            englandTeam.Display();
        }
    }
}
