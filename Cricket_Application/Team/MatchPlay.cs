using Cricket_Application.Models;
using Cricket_Application.Teams;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Application.Team
{
    public class MatchPlay
    {
        public int Ban_Run { get; }
        public int Ban_Over { get; }
        public int Eng_Run { get; }
        public int Eng_Over { get; }

        private  BangladeshTeam bangladeshTeam;
        private  EnglandTeam englandTeam;
        List<CricketPlayer> BanPlayers;
        List<CricketPlayer> EngPlayers;
        public MatchPlay(BangladeshTeam bangladeshTeam, EnglandTeam englandTeam)
        {
            this.bangladeshTeam = bangladeshTeam;
            this.englandTeam = englandTeam;
        }
        public void FirstInnings(int total_players, int total_match_over)
        {
            EngPlayers = englandTeam.GetPlayers();
            BanPlayers = bangladeshTeam.GetPlayers();
            var random = new Random();
            int countBang = 0, countEng = 0, total_run = 0, p1_run = 0, p2_run = 0, total_over = 5, not_out_players = total_players, baller_stack = 3, running_over = 0;
          

            do
            {

                do
                {


                    while (total_over > 0 && total_over <= 5 && not_out_players > 1 && not_out_players <= not_out_players + 1)
                    {
                        running_over++;
                        int running_ball = 0;
                        int over_ball = 1;
                        Console.Clear();
                        Console.WriteLine($"BAN : {total_run}    Over: {running_over}.{running_ball}");
                        Console.WriteLine($"{BanPlayers[countBang].Name} : {p1_run}\n{BanPlayers[countBang + 1].Name} : {p2_run}");
                        Console.WriteLine($"England boller Name: {EngPlayers[countEng].Name}");


                        while (over_ball > 0 && over_ball <= 6)
                        {
                            int run = random.Next(0, 10);

                            if (run == 1 || run == 2 || run == 3 || run == 4 || run == 6)
                            {
                                total_run = total_run + run;
                                over_ball++;
                                running_ball = over_ball;
                            }
                            else if (run == 5 || run == 7 || run == 8 || run == 9 || run == 10)
                            {
                                if (run == 5)
                                {
                                    Console.WriteLine("No Ball!");
                                no_ball_runStart:
                                    int no_ball_run = random.Next(6);
                                    if (no_ball_run == 5)
                                        goto no_ball_runStart;
                                    total_run = total_run + no_ball_run;

                                    over_ball++;
                                    running_ball = over_ball;
                                }
                                else if (run == 7)
                                {
                                    Console.WriteLine("White Ball!");
                                    total_run = total_run + 1;
                                }
                                else if (run == 8)
                                {
                                    Console.WriteLine("Out!");
                                    not_out_players = not_out_players - 1;
                                    over_ball++;
                                    running_ball = over_ball;
                                }

                            }
                            else if (run == 0)
                            {
                                over_ball++;
                                running_ball = over_ball;
                            }
                        }
                        total_over = total_over - 1;
                    }
                    baller_stack = baller_stack - 1;
                    //countEng++;
                } while (baller_stack > 0 && baller_stack <= baller_stack + 1);
                //countBang++;
            } while (not_out_players > 1 && not_out_players <= not_out_players + 1);
        }
        public void SecondInnings()
        {
            EngPlayers = englandTeam.GetPlayers();
            BanPlayers = bangladeshTeam.GetPlayers();
        }
        public void Display() 
        {
            Console.Clear();
            //Console.Write("\nTotal Run: " + result + " = " + total_run);
            //Console.Write($"\tTotal Over: {running_over}");

            Console.WriteLine($"Nothing!");
        }

    }
}
