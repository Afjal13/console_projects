﻿using Cricket_Application.Models;
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
        public int Ban_Run { get; set; }
        public int Ban_Over { get; set; }
        public int Ban_Win_Player { get; set; }
        public int Ban_Running_ball { get; set; }
        public int Ban_out_players { get; set; }
        public int Eng_Run { get; set; }
        public int Eng_Over { get; set; }
        public int Eng_Win_Player { get; set; }
        public int Eng_Running_ball { get; set; }
        public int Eng_out_players { get; set; }
        private BangladeshTeam bangladeshTeam;
        private EnglandTeam englandTeam;
        List<CricketPlayer> BanPlayers;
        List<CricketPlayer> EngPlayers;
        List<int> outPlayerList = new List<int>();
        public int tossWinResult { get; set; }
        public MatchPlay(BangladeshTeam bangladeshTeam, EnglandTeam englandTeam, int tossWinResult)
        {
            this.bangladeshTeam = bangladeshTeam;
            this.englandTeam = englandTeam;
            this.tossWinResult = tossWinResult;
        }
        public void FirstInnings(int total_players, int total_match_over, int toss_win)
        {
            EngPlayers = englandTeam.GetPlayers();
            BanPlayers = bangladeshTeam.GetPlayers();
            int countEng = 0, total_run = 0, p1_run = 0, p2_run = 0, total_over = total_match_over, not_out_players = total_players, baller_stack = 3, total_ball = 0, temp = 0;
            int batsman1 = 0, batsman2 = 1, default_out = 2, swapVariableData,run = 0;
            bool match_end = false;

            do
            {
                do
                {
                    while (total_over > 0 && total_over <= total_match_over && not_out_players > 1 && not_out_players <= not_out_players + 1)
                    {
                        if (toss_win == 1)
                        {
                            if (temp < 0)
                                break;
                            else
                            {
                                int over_ball = 1;
                                Console.WriteLine($"England boller Name: {EngPlayers[countEng].Name}");
                                while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                                {
                                    if (over_ball != 6)
                                        Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                    else
                                        Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");

                                    Console.WriteLine($"{BanPlayers[batsman1].Name} : {p1_run}\n{BanPlayers[batsman2].Name} : {p2_run}");
                                    if (toss_win == 1)
                                    {
                                        temp = Eng_Run - total_run;
                                        if (temp < 0)
                                            break;
                                        else
                                        {
                                            var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                            run = throwBallEvents.Item1;
                                            default_out=throwBallEvents.Item2;
                                            total_run = throwBallEvents.Item3;
                                            over_ball = throwBallEvents.Item4;
                                            total_ball = throwBallEvents.Item5;
                                            batsman1 = throwBallEvents.Item6;
                                            batsman2 = throwBallEvents.Item7;
                                            not_out_players = throwBallEvents.Item8;
                                            if (not_out_players == 1)
                                            {
                                                match_end = true;
                                                break;
                                            }                                          
                                        }
                                    }
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                        run = throwBallEvents.Item1;
                                        default_out = throwBallEvents.Item2;
                                        total_run = throwBallEvents.Item3;
                                        over_ball = throwBallEvents.Item4;
                                        total_ball = throwBallEvents.Item5;
                                        batsman1 = throwBallEvents.Item6;
                                        batsman2 = throwBallEvents.Item7;
                                        not_out_players = throwBallEvents.Item8;
                                        if (not_out_players == 1)
                                        {
                                            match_end = true;
                                            break;
                                        }                                     
                                    }
                                }
                                total_over = total_over - 1;

                                if (default_out == 2)
                                {
                                    if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                    {
                                        swapVariableData = batsman2;
                                        batsman2 = batsman1;
                                        batsman1 = swapVariableData;
                                        default_out = 1;
                                    }
                                }
                                else
                                {
                                    if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                    {
                                        swapVariableData = batsman2;
                                        batsman2 = batsman1;
                                        batsman1 = swapVariableData;
                                        default_out = 2;
                                    }
                                }
                                if (total_over == 0)
                                    match_end = true;
                            }
                        }
                        else
                        {
                            int over_ball = 1;
                            Console.WriteLine($"England boller Name: {EngPlayers[countEng].Name}");
                            while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                            {
                                if (over_ball != 6)
                                    Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                else
                                    Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");
                                Console.WriteLine($"{BanPlayers[batsman1].Name} : {p1_run}\n{BanPlayers[batsman2].Name} : {p2_run}");
                                if (toss_win == 1)
                                {
                                    temp = Eng_Run - total_run;
                                    if (temp < 0)
                                        break;
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                        run = throwBallEvents.Item1;
                                        default_out = throwBallEvents.Item2;
                                        total_run = throwBallEvents.Item3;
                                        over_ball = throwBallEvents.Item4;
                                        total_ball = throwBallEvents.Item5;
                                        batsman1 = throwBallEvents.Item6;
                                        batsman2 = throwBallEvents.Item7;
                                        not_out_players = throwBallEvents.Item8;
                                        if (not_out_players == 1)
                                        {
                                            match_end = true;
                                            break;
                                        }                                      
                                    }
                                }
                                else
                                {
                                    var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                    run = throwBallEvents.Item1;
                                    default_out = throwBallEvents.Item2;
                                    total_run = throwBallEvents.Item3;
                                    over_ball = throwBallEvents.Item4;
                                    total_ball = throwBallEvents.Item5;
                                    batsman1 = throwBallEvents.Item6;
                                    batsman2 = throwBallEvents.Item7;
                                    not_out_players = throwBallEvents.Item8;
                                    if (not_out_players == 1)
                                    {
                                        match_end = true;
                                        break;
                                    }                                  
                                }
                            }
                            total_over = total_over - 1;

                            if (default_out == 2)
                            {
                                if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                {
                                    swapVariableData = batsman2;
                                    batsman2 = batsman1;
                                    batsman1 = swapVariableData;
                                    default_out = 1;
                                }
                            }
                            else
                            {
                                if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                {
                                    swapVariableData = batsman2;
                                    batsman2 = batsman1;
                                    batsman1 = swapVariableData;
                                    default_out = 2;
                                }
                            }

                            if (total_over == 0)
                                match_end = true;
                        }
                    }
                    if (toss_win == 1)
                    {
                        if (temp < 0)
                        {
                            break;
                        }
                        else
                        {
                            baller_stack = baller_stack - 1;
                            if (match_end == true)
                                break;
                        }
                    }
                    else
                    {
                        baller_stack = baller_stack - 1;
                        if (match_end == true)
                            break;
                    }
                } while (baller_stack > 0 && baller_stack <= baller_stack + 1);
                if (toss_win == 1)
                {
                    if (temp < 0)
                    {
                        break;
                    }
                }
                if (total_over == 0)
                    break;

            } while (not_out_players > 1 && not_out_players <= not_out_players + 1);

            Ban_Over = total_ball / 6;
            Ban_Running_ball = total_ball % 6;
            Ban_Run = total_run;
            Ban_Win_Player = not_out_players;
            Ban_out_players = total_players - not_out_players;
        }

        public void SecondInnings(int total_players, int total_match_over, int toss_win)
        {
            EngPlayers = englandTeam.GetPlayers();
            BanPlayers = bangladeshTeam.GetPlayers();
            int countEng = 0, total_run = 0, p1_run = 0, p2_run = 0, total_over = total_match_over, not_out_players = total_players, baller_stack = 3, total_ball = 0, temp = 0;
            int batsman1 = 0, batsman2 = 1, default_out = 2, swapVariableData, run = 0;
            bool match_end = false;

            do
            {
                do
                {
                    while (total_over > 0 && total_over <= total_match_over && not_out_players > 1 && not_out_players <= not_out_players + 1)
                    {
                        if (toss_win == 0)
                        {
                            if (temp < 0)
                                break;
                            else
                            {
                                int over_ball = 1;
                                Console.WriteLine($"Bangladesh boller Name: {BanPlayers[countEng].Name}");
                                while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                                {
                                    if (over_ball != 6)
                                        Console.WriteLine($"ENG : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                    else
                                        Console.WriteLine($"ENG : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");

                                    Console.WriteLine($"{EngPlayers[batsman1].Name} : {p1_run}\n{EngPlayers[batsman2].Name} : {p2_run}");
                                    if (toss_win == 0)
                                    {
                                        temp = Ban_Run - total_run;
                                        if (temp < 0)
                                            break;
                                        else
                                        {
                                            var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players,tossWinResult);
                                            run = throwBallEvents.Item1;
                                            default_out = throwBallEvents.Item2;
                                            total_run = throwBallEvents.Item3;
                                            over_ball = throwBallEvents.Item4;
                                            total_ball = throwBallEvents.Item5;
                                            batsman1 = throwBallEvents.Item6;
                                            batsman2 = throwBallEvents.Item7;
                                            not_out_players = throwBallEvents.Item8;
                                            if (not_out_players == 1)
                                            {
                                                match_end = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                        run = throwBallEvents.Item1;
                                        default_out = throwBallEvents.Item2;
                                        total_run = throwBallEvents.Item3;
                                        over_ball = throwBallEvents.Item4;
                                        total_ball = throwBallEvents.Item5;
                                        batsman1 = throwBallEvents.Item6;
                                        batsman2 = throwBallEvents.Item7;
                                        not_out_players = throwBallEvents.Item8;
                                        if (not_out_players == 1)
                                        {
                                            match_end = true;
                                            break;
                                        }
                                    }
                                }
                                total_over = total_over - 1;

                                if (default_out == 2)
                                {
                                    if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                    {
                                        swapVariableData = batsman2;
                                        batsman2 = batsman1;
                                        batsman1 = swapVariableData;
                                        default_out = 1;
                                    }
                                }
                                else
                                {
                                    if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                    {
                                        swapVariableData = batsman2;
                                        batsman2 = batsman1;
                                        batsman1 = swapVariableData;
                                        default_out = 2;
                                    }
                                }
                                if (total_over == 0)
                                    match_end = true;
                            }
                        }
                        else
                        {
                            int over_ball = 1;
                            Console.WriteLine($"Bangladesh boller Name: {BanPlayers[countEng].Name}");
                            while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                            {
                                if (over_ball != 6)
                                    Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                else
                                    Console.WriteLine($"BAN : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");
                                Console.WriteLine($"{EngPlayers[batsman1].Name} : {p1_run}\n{EngPlayers[batsman2].Name} : {p2_run}");
                                if (toss_win == 0)
                                {
                                    temp = Ban_Run - total_run;
                                    if (temp < 0)
                                        break;
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                        run = throwBallEvents.Item1;
                                        default_out = throwBallEvents.Item2;
                                        total_run = throwBallEvents.Item3;
                                        over_ball = throwBallEvents.Item4;
                                        total_ball = throwBallEvents.Item5;
                                        batsman1 = throwBallEvents.Item6;
                                        batsman2 = throwBallEvents.Item7;
                                        not_out_players = throwBallEvents.Item8;
                                        if (not_out_players == 1)
                                        {
                                            match_end = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult);
                                    run = throwBallEvents.Item1;
                                    default_out = throwBallEvents.Item2;
                                    total_run = throwBallEvents.Item3;
                                    over_ball = throwBallEvents.Item4;
                                    total_ball = throwBallEvents.Item5;
                                    batsman1 = throwBallEvents.Item6;
                                    batsman2 = throwBallEvents.Item7;
                                    not_out_players = throwBallEvents.Item8;
                                    if (not_out_players == 1)
                                    {
                                        match_end = true;
                                        break;
                                    }
                                }
                            }
                            total_over = total_over - 1;

                            if (default_out == 2)
                            {
                                if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                {
                                    swapVariableData = batsman2;
                                    batsman2 = batsman1;
                                    batsman1 = swapVariableData;
                                    default_out = 1;
                                }
                            }
                            else
                            {
                                if (run == 0 || run == 2 || run == 4 || run == 6 || run == 8)
                                {
                                    swapVariableData = batsman2;
                                    batsman2 = batsman1;
                                    batsman1 = swapVariableData;
                                    default_out = 2;
                                }
                            }

                            if (total_over == 0)
                                match_end = true;
                        }
                    }
                    if (toss_win == 0)
                    {
                        if (temp < 0)
                        {
                            break;
                        }
                        else
                        {
                            baller_stack = baller_stack - 1;
                            if (match_end == true)
                                break;
                        }
                    }
                    else
                    {
                        baller_stack = baller_stack - 1;
                        if (match_end == true)
                            break;
                    }
                } while (baller_stack > 0 && baller_stack <= baller_stack + 1);
                if (toss_win == 0)
                {
                    if (temp < 0)
                    {
                        break;
                    }
                }
                if (total_over == 0)
                    break;

            } while (not_out_players > 1 && not_out_players <= not_out_players + 1);

            Eng_Over = total_ball / 6;
            Eng_Running_ball = total_ball % 6;
            Eng_Run = total_run;
            Eng_Win_Player = not_out_players;
            Eng_out_players = total_players - not_out_players;
        }

        public void Display(int toss_win)
        {
            int win_run = 0;
            //  Console.Clear();
            string toss_win_country = (toss_win == 0) ? "Bangladesh" : "England";
            Console.WriteLine($"{toss_win_country} won the toss!");
            if (toss_win == 0)
            {
                if (Ban_Run > Eng_Run)
                {
                    win_run = Ban_Run - Eng_Run;
                    Console.WriteLine($"Bangladesh Run: {Ban_Run}/{Ban_out_players}\tOver: {Ban_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Run: {Eng_Run}/{Eng_out_players}\tOver: {Eng_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"Bangladesh Win by {win_run} runs!");
                }
                else
                {
                    Console.WriteLine($"Bangladesh Run: {Ban_Run}/{Ban_out_players}\tOver: {Ban_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Run: {Eng_Run}/{Eng_out_players}\tOver: {Eng_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Win by {Eng_Win_Player} Wickets!");
                }
            }
            else
            {
                if (Ban_Run > Eng_Run)
                {
                    Console.WriteLine($"Bangladesh Run: {Ban_Run}/{Ban_out_players}\tOver: {Ban_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Run: {Eng_Run}/{Eng_out_players}\tOver: {Eng_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"Bangladesh Win by {Ban_Win_Player} Wickets!");
                }
                else
                {
                    win_run = Eng_Run - Ban_Run;
                    Console.WriteLine($"Bangladesh Run: {Ban_Run}/{Ban_out_players}\tOver: {Ban_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Run: {Eng_Run}/{Eng_out_players}\tOver: {Eng_Over}.{Ban_Running_ball}");
                    Console.WriteLine($"England Win by {win_run} runs!");

                }

            }

        }

        public bool IsPlayerAlreadyOut(int out_player)
        {
            bool isOut = false;
            if (outPlayerList.Contains(out_player))
                isOut = true;
            return isOut;
        }

        public int NewBatsman(int outBatsman, int totalOfPlayer, int opositeBatsman)
        {
            int k = 1;
            for (int i = 3; i <= 11; i++)
            {
                if ((outBatsman + k) < totalOfPlayer && (outBatsman + k) != opositeBatsman && IsPlayerAlreadyOut(outBatsman + k) == false)
                {
                    outBatsman += k;
                    break;
                }
                else
                {
                    k++;
                }
            }
            return outBatsman;
        }

        public (int, int, int, int, int, int, int, int) ThrowBallEvent(int preBallRun, int default_out, int total_run, int over_ball, int total_ball, int batsman1, int batsman2, int not_out_players, int toss) // tuple return type
        {
            EngPlayers = englandTeam.GetPlayers();
            BanPlayers = bangladeshTeam.GetPlayers();
            var random = new Random();
            int run, swapVariableData;
            var runList = new List<int>() { 0, 1, 0, 0, 3, 0, 1, 0, 7, 1, 2, 0, 1, 2, 0, 1, 1, 0, 2, 0, 1, 8, 0, 0, 1, 0, 0, 1, 1, 1, 6, 0, 0, 1, 4, 1, 0, 2, 1, 0, 1, 1, 5, 0, 0, 0, 2, 1, 1, 0 };

            int index = random.Next(runList.Count);
            run = runList[index];
            if (run == 5 || run == 7 || run == 8)
                default_out = 2;
            if (run == 1 || run == 2 || run == 3 || run == 4 || run == 6)
            {
                if (run == 2 || run == 4 || run == 6)
                {
                    //for even run 
                    if (default_out == 2)
                        default_out = 2;
                    else
                        default_out = 1;
                }
                else
                {
                    //for odd run 
                    swapVariableData = batsman2;
                    batsman2 = batsman1;
                    batsman1 = swapVariableData;
                    if (default_out == 2)
                        default_out = 1;
                    else
                        default_out = 2;
                }
                total_run = total_run + run;
                over_ball++;
                total_ball++;
            }
            else if (run == 5 || run == 7 || run == 8)
            {
                if (run == 5)
                {
                    Console.WriteLine("No Ball!");
                no_ball_runStart:
                    int no_ball_run = random.Next(6);
                    if (no_ball_run == 5)
                        goto no_ball_runStart;
                    run = no_ball_run;
                    if (no_ball_run == 0)
                    {
                        over_ball++;
                        total_ball++;
                    }
                    else
                    {
                        if (no_ball_run == 2 || no_ball_run == 4 || no_ball_run == 6)
                        {
                            //for even run 
                            if (default_out == 2)
                                default_out = 2;
                            else
                                default_out = 1;
                        }
                        else
                        {
                            //for odd run 
                            swapVariableData = batsman2;
                            batsman2 = batsman1;
                            batsman1 = swapVariableData;
                            if (default_out == 2)
                                default_out = 1;
                            else
                                default_out = 2;
                        }
                        total_run = total_run + no_ball_run;
                        over_ball++;
                        total_ball++;
                    }
                }
                else if (run == 7)
                {
                    int White_ball_run = random.Next(100);
                    if (White_ball_run >= 0 && White_ball_run <= 6)
                    {
                        if (White_ball_run == 0)
                        {
                            run = 0;
                            over_ball++;
                            total_ball++;
                        }
                        else if (White_ball_run == 1 || White_ball_run == 2 || White_ball_run == 3 || White_ball_run == 4 || White_ball_run == 6)
                        {
                            run = White_ball_run;
                            if (White_ball_run == 2 || White_ball_run == 4 || White_ball_run == 6)
                            {
                                //for even run 
                                if (default_out == 2)
                                    default_out = 2;
                                else
                                    default_out = 1;
                            }
                            else
                            {
                                ////for odd run 
                                swapVariableData = batsman2;
                                batsman2 = batsman1;
                                batsman1 = swapVariableData;
                                if (default_out == 2)
                                    default_out = 1;
                                else
                                    default_out = 2;
                            }
                            total_run = total_run + White_ball_run;
                            over_ball++;
                            total_ball++;
                        }
                        else
                        {
                            run = 8;
                            Console.WriteLine("Out!");
                            not_out_players = not_out_players - 1;
                            if (default_out == 2)
                            {
                                outPlayerList.Add(batsman2);
                                if(toss==1)
                                    batsman2 = NewBatsman(batsman2, BanPlayers.Count, batsman1);
                                else
                                    batsman2 = NewBatsman(batsman2, EngPlayers.Count, batsman1);
                            }
                            else if (default_out == 1)
                            {
                                outPlayerList.Add(batsman1);
                                if(toss==1)
                                     batsman1 = NewBatsman(batsman1, BanPlayers.Count, batsman2);
                                else
                                    batsman1 = NewBatsman(batsman1, EngPlayers.Count, batsman2);
                            }
                            over_ball++;
                            total_ball++;
                        }
                    }
                    else
                    {
                        run = 0;
                        Console.WriteLine("White Ball!");
                        total_run = total_run + 1;
                    }
                }
                else if (run == 8)
                {
                    run = 8;
                    Console.WriteLine("Out!");
                    not_out_players = not_out_players - 1;
                    if (default_out == 2)
                    {
                        outPlayerList.Add(batsman2);
                        if (toss == 1)
                            batsman2 = NewBatsman(batsman2, BanPlayers.Count, batsman1);
                        else
                            batsman2 = NewBatsman(batsman2, EngPlayers.Count, batsman1);
                    }
                    else if (default_out == 1)
                    {
                        outPlayerList.Add(batsman1);
                        if(toss == 1)
                            batsman1 = NewBatsman(batsman1, BanPlayers.Count, batsman2);
                        else
                            batsman1 = NewBatsman(batsman1, EngPlayers.Count, batsman2);
                    }
                    over_ball++;
                    total_ball++;
                }
            }
            else if (run == 0)
            {
                run = 0;
                over_ball++;
                total_ball++;
            }

            preBallRun = run;
            return (preBallRun, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players); // tuple literal
        }
    }
}
