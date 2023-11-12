using Cricket_Application.Models;
using Cricket_Application.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Application.Team
{
    public class MatchPlay
    {
        public string? FirstTeamName { get; set; }
        public int FirstTeamRun { get; set; }
        public int FirstTeamOver { get; set; }
        public int FirstTeamWinPlayer { get; set; }
        public int FirstTeamRunningBalls { get; set; }
        public int FirstTeamOutPlayers { get; set; }
        public string? SecondTeamName { get; set; }
        public int SecondTeamRun { get; set; }
        public int SecondTeamOver { get; set; }
        public int SecondTeamWinPlayer { get; set; }
        public int SecondTeamRunningBalls { get; set; }
        public int SecondTeamOutPlayers { get; set; }
        private FirstTeam _firstTeam;
        private SecondTeam _secondTeam;
        List<CricketPlayer> FirstTeamPlayers;
        List<CricketPlayer> SecondTeamPlayers;
        List<int> OutPlayerFirstTeamLists = new List<int>();
        List<int> OutPlayerSecondTeamLists = new List<int>();
        List<int> FirstTeamBallerList = new List<int>();
        List<int> SecondTeamBallerList = new List<int>();
        Dictionary<int, int> FirstTeamBallerOverStackLists = new Dictionary<int, int>();
        Dictionary<int, int> SecondTeamBallerOverStackLists = new Dictionary<int, int>();
        public int tossWinResult { get; set; }
        public MatchPlay(FirstTeam firstTeam, SecondTeam secondTeam, int tossWinResult, string? firstTeamName, string? secondTeamName)
        {
            this._firstTeam = firstTeam;
            this._secondTeam = secondTeam;
            this.tossWinResult = tossWinResult;
            this.FirstTeamName = firstTeamName;
            this.SecondTeamName = secondTeamName;
            // Initialize the player lists
            this.FirstTeamPlayers = new List<CricketPlayer>();
            this.SecondTeamPlayers = new List<CricketPlayer>();
        }
        public void FirstInnings(int total_players, int total_match_over, int toss_win, int battingTeam, string? firstTeamName, string? secondTeamName)
        {
            SecondTeamPlayers = _secondTeam.GetPlayers() ?? new List<CricketPlayer>();
            FirstTeamPlayers = _firstTeam.GetPlayers() ?? new List<CricketPlayer>();
            int total_run = 0, p1_run = 0, p2_run = 0, total_over = total_match_over, not_out_players = total_players, baller_stack = 3, total_ball = 0, temp = 0;
            int batsman1 = 0, batsman2 = 1, default_out = 2, swapVariableData, run = 0, lastBallerId = -1;
            bool match_end = false;

            AddBallerLists(SecondTeamPlayers);
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
                                lastBallerId = GetBaller(SecondTeamBallerList, lastBallerId, battingTeam, total_match_over);
                                OverStackOfBaller(lastBallerId, battingTeam);
                                Console.WriteLine($"{secondTeamName} Baller Name: 👨 {SecondTeamPlayers[lastBallerId].Name}");
                                while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                                {
                                    if (over_ball != 6)
                                        Console.WriteLine($"{firstTeamName} : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                    else
                                        Console.WriteLine($"{firstTeamName} : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");

                                    Console.WriteLine($"👨 {FirstTeamPlayers[batsman1].Name} : {p1_run}\n👨 {FirstTeamPlayers[batsman2].Name} : {p2_run}");
                                    if (toss_win == 1)
                                    {
                                        temp = SecondTeamRun - total_run;
                                        if (temp < 0)
                                            break;
                                        else
                                        {
                                            var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                            lastBallerId = GetBaller(SecondTeamBallerList, lastBallerId, battingTeam, total_match_over);
                            OverStackOfBaller(lastBallerId, battingTeam);
                            Console.WriteLine($"{secondTeamName} Baller Name: 👨 {SecondTeamPlayers[lastBallerId].Name}");
                            while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                            {
                                if (over_ball != 6)
                                    Console.WriteLine($"{firstTeamName}  : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                else
                                    Console.WriteLine($"{firstTeamName}  : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");
                                Console.WriteLine($"👨 {FirstTeamPlayers[batsman1].Name} : {p1_run}\n👨 {FirstTeamPlayers[batsman2].Name} : {p2_run}");
                                if (toss_win == 1)
                                {
                                    temp = SecondTeamRun - total_run;
                                    if (temp < 0)
                                        break;
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                                    var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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

            FirstTeamOver = total_ball / 6;
            FirstTeamRunningBalls = total_ball % 6;
            FirstTeamRun = total_run;
            FirstTeamWinPlayer = not_out_players;
            FirstTeamOutPlayers = total_players - not_out_players;
        }

        public void SecondInnings(int total_players, int total_match_over, int toss_win, int battingTeam, string? firstTeamName, string? secondTeamName)
        {
            SecondTeamPlayers = _secondTeam.GetPlayers() ?? new List<CricketPlayer>();
            FirstTeamPlayers = _firstTeam.GetPlayers() ?? new List<CricketPlayer>();
            int total_run = 0, p1_run = 0, p2_run = 0, total_over = total_match_over, not_out_players = total_players, baller_stack = 3, total_ball = 0, temp = 0;
            int batsman1 = 0, batsman2 = 1, default_out = 2, swapVariableData, run = 0, lastBallerId=-1;
            bool match_end = false;
            AddBallerLists(FirstTeamPlayers);
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
                                lastBallerId = GetBaller(FirstTeamBallerList, lastBallerId, battingTeam, total_match_over);
                                OverStackOfBaller(lastBallerId, battingTeam);
                                Console.WriteLine($"{firstTeamName} Baller Name: 👨 {FirstTeamPlayers[lastBallerId].Name}");
                                while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                                {
                                    if (over_ball != 6)
                                        Console.WriteLine($"{secondTeamName} : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                    else
                                        Console.WriteLine($"{secondTeamName} : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");

                                    Console.WriteLine($"👨 {SecondTeamPlayers[batsman1].Name} : {p1_run}\n👨 {SecondTeamPlayers[batsman2].Name} : {p2_run}");
                                    if (toss_win == 0)
                                    {
                                        temp = FirstTeamRun - total_run;
                                        if (temp < 0)
                                            break;
                                        else
                                        {
                                            var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                            lastBallerId = GetBaller(FirstTeamBallerList, lastBallerId, battingTeam, total_match_over);
                            OverStackOfBaller(lastBallerId, battingTeam);
                            Console.WriteLine($"{firstTeamName} Baller Name: 👨 {FirstTeamPlayers[lastBallerId].Name}");
                            while (over_ball > 0 && over_ball <= 6 && not_out_players <= not_out_players + 1)
                            {
                                if (over_ball != 6)
                                    Console.WriteLine($"{secondTeamName}  : {total_run}/{total_players - not_out_players}\tOver: {total_ball / 6}.{(total_ball % 6) + 1}");
                                else
                                    Console.WriteLine($"{secondTeamName} : {total_run}/{total_players - not_out_players}\tOver: {(total_ball / 6) + 1}.{0}");
                                Console.WriteLine($"👨 {SecondTeamPlayers[batsman1].Name} : {p1_run}\n👨 {SecondTeamPlayers[batsman2].Name} : {p2_run}");
                                if (toss_win == 0)
                                {
                                    temp = FirstTeamRun - total_run;
                                    if (temp < 0)
                                        break;
                                    else
                                    {
                                        var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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
                                    var throwBallEvents = ThrowBallEvent(run, default_out, total_run, over_ball, total_ball, batsman1, batsman2, not_out_players, tossWinResult, battingTeam);
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

            SecondTeamOver = total_ball / 6;
            SecondTeamRunningBalls = total_ball % 6;
            SecondTeamRun = total_run;
            SecondTeamWinPlayer = not_out_players;
            SecondTeamOutPlayers = total_players - not_out_players;
        }

        public void Display(int toss_win, string? firstTeamName, string? secondTeamName)
        {
            int win_run = 0;
            //  Console.Clear();
            string? toss_win_country = (toss_win == 0) ? firstTeamName : secondTeamName;
            Console.WriteLine($"{toss_win_country} won the toss!");
            if (toss_win == 0)
            {
                if (FirstTeamRun > SecondTeamRun)
                {
                    win_run = FirstTeamRun - SecondTeamRun;
                    Console.WriteLine($"{firstTeamName} Run: {FirstTeamRun}/{FirstTeamOutPlayers}\tOver: {FirstTeamOver}.{FirstTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Run: {SecondTeamRun}/{SecondTeamOutPlayers}\tOver: {SecondTeamOver}.{SecondTeamRunningBalls}");
                    Console.WriteLine($"{firstTeamName} Win by {win_run} runs!");
                }
                else
                {
                    Console.WriteLine($"{firstTeamName} Run: {FirstTeamRun}/{FirstTeamOutPlayers}\tOver: {FirstTeamOver}.{FirstTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Run: {SecondTeamRun}/{SecondTeamOutPlayers}\tOver: {SecondTeamOver}.{SecondTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Win by {SecondTeamWinPlayer} Wickets!");
                }
            }
            else
            {
                if (FirstTeamRun > SecondTeamRun)
                {
                    Console.WriteLine($"{firstTeamName} Run: {FirstTeamRun}/{FirstTeamOutPlayers}\tOver: {FirstTeamOver}.{FirstTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Run: {SecondTeamRun}/{SecondTeamOutPlayers}\tOver: {SecondTeamOver}.{SecondTeamRunningBalls}");
                    Console.WriteLine($"{firstTeamName} Win by {FirstTeamWinPlayer} Wickets!");
                }
                else
                {
                    win_run = SecondTeamRun - FirstTeamRun;
                    Console.WriteLine($"{firstTeamName} Run: {FirstTeamRun}/{FirstTeamOutPlayers}\tOver: {FirstTeamOver}.{FirstTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Run: {SecondTeamRun}/{SecondTeamOutPlayers}\tOver: {SecondTeamOver}.{SecondTeamRunningBalls}");
                    Console.WriteLine($"{secondTeamName} Win by {win_run} runs!");

                }

            }

        }

        public bool IsPlayerAlreadyOut(int out_player, int battingTeam)
        {
            bool isOut = false;
            if (battingTeam == 0)
            {
                if (OutPlayerFirstTeamLists.Contains(out_player))
                    isOut = true;
            }
            else
            {
                if (OutPlayerSecondTeamLists.Contains(out_player))
                    isOut = true;
            }

            return isOut;
        }

        public int NewBatsman(int outBatsman, int totalOfPlayer, int opositeBatsman, int battingTeam)
        {
            int k = 1;
            for (int i = 3; i <= 11; i++)
            {
                if ((outBatsman + k) < totalOfPlayer && (outBatsman + k) != opositeBatsman && IsPlayerAlreadyOut(outBatsman + k, battingTeam) == false)
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

        public (int, int, int, int, int, int, int, int) ThrowBallEvent(int preBallRun, int default_out, int total_run, int over_ball, int total_ball, int batsman1, int batsman2, int not_out_players, int toss, int battingTeam) // tuple return type
        {
            SecondTeamPlayers = _secondTeam.GetPlayers();
            FirstTeamPlayers = _firstTeam.GetPlayers();
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
                                if (battingTeam == 0)
                                {
                                    OutPlayerFirstTeamLists.Add(batsman2);
                                    batsman2 = NewBatsman(batsman2, FirstTeamPlayers.Count, batsman1, battingTeam);
                                }
                                else
                                {
                                    OutPlayerSecondTeamLists.Add(batsman2);
                                    batsman2 = NewBatsman(batsman2, SecondTeamPlayers.Count, batsman1, battingTeam);
                                }
                            }
                            else if (default_out == 1)
                            {
                                if (battingTeam == 0)
                                {
                                    OutPlayerFirstTeamLists.Add(batsman1);
                                    batsman1 = NewBatsman(batsman1, FirstTeamPlayers.Count, batsman2, battingTeam);
                                }
                                else
                                {
                                    OutPlayerSecondTeamLists.Add(batsman1);
                                    batsman1 = NewBatsman(batsman1, SecondTeamPlayers.Count, batsman2, battingTeam);
                                }

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
                        if (battingTeam == 0)
                        {
                            OutPlayerFirstTeamLists.Add(batsman2);
                            batsman2 = NewBatsman(batsman2, FirstTeamPlayers.Count, batsman1, battingTeam);
                        }
                        else
                        {
                            OutPlayerSecondTeamLists.Add(batsman2);
                            batsman2 = NewBatsman(batsman2, SecondTeamPlayers.Count, batsman1, battingTeam);
                        }
                    }
                    else if (default_out == 1)
                    {
                        if (battingTeam == 0)
                        {
                            OutPlayerFirstTeamLists.Add(batsman1);
                            batsman1 = NewBatsman(batsman1, FirstTeamPlayers.Count, batsman2, battingTeam);
                        }
                        else
                        {
                            OutPlayerSecondTeamLists.Add(batsman1);
                            batsman1 = NewBatsman(batsman1, SecondTeamPlayers.Count, batsman2, battingTeam);
                        }

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

        public void AddBallerLists(List<CricketPlayer> cricketPlayerLists)
        {
            for (int i = 0; i < cricketPlayerLists.Count; i++)
            {
                var currentPlayer = cricketPlayerLists[i];

                if (currentPlayer != null && currentPlayer.Title != null && (currentPlayer.Title.ToLower() == "baller" || currentPlayer.Title.ToLower() == "allrounder"))
                {
                    if (currentPlayer.Country == FirstTeamName)
                        FirstTeamBallerList.Add(i);
                    else
                        SecondTeamBallerList.Add(i);
                }
            }
        }

        public int GetBaller(List<int> ballerList, int lastBallerId, int battingTeam, int totalOver)
        {
            int totalBaller = ballerList.Count;
            int eachBallerMaxOver = totalOver / ballerList.Count;
            int ballerIndex, ballerId, baller, extraballer;
            var random = new Random();
        MakeBaller:
            ballerIndex = random.Next(totalBaller);
            ballerId = ballerList[ballerIndex];


            if (ballerId == lastBallerId)
                goto MakeBaller;
            else
            {
                if (battingTeam == 0)
                {
                    if (eachBallerMaxOver <= 10)
                    {
                        if (SecondTeamBallerOverStackLists.ContainsKey(ballerId))
                        {
                            if (SecondTeamBallerOverStackLists[ballerId] < 10)
                            {
                                baller = ballerId;
                            }
                            else
                            {
                                goto MakeBaller;
                            }
                        }
                        else
                        {
                            baller = ballerId;
                        }
                    }
                    else
                    {
                        extraballer = 5 - totalBaller;
                        AddExtraBaller(SecondTeamPlayers, extraballer);
                        baller = ballerId;
                    }
                   
                }
                else
                {
                    if (eachBallerMaxOver <= 10)
                    {
                        if (FirstTeamBallerOverStackLists.ContainsKey(ballerId))
                        {
                            if (FirstTeamBallerOverStackLists[ballerId] < 10)
                            {
                                baller = ballerId;
                            }
                            else
                            {
                                goto MakeBaller;
                            }
                        }
                        else
                        {
                            baller = ballerId;
                        }
                    }
                    else
                    {
                        extraballer = 5 - totalBaller;
                        AddExtraBaller(FirstTeamPlayers, extraballer);
                        baller = ballerId;
                    }
            
                }
            }
            
               


            return baller;
        }

        public void OverStackOfBaller(int ballerId, int battingTeam)
        {
            int newOver;   
            if(battingTeam == 0)
            {
                if(SecondTeamBallerOverStackLists != null)
                {
                    if (SecondTeamBallerOverStackLists.ContainsKey(ballerId))
                    {
                        int lastContainOver = SecondTeamBallerOverStackLists[ballerId];
                        newOver = lastContainOver + 1;
                        SecondTeamBallerOverStackLists[ballerId]=newOver;
                     
                    }
                    else
                    {
                        SecondTeamBallerOverStackLists.Add(ballerId, 1);
                    }

                }
                //else
                //{
                //    SecondTeamBallerOverStackLists.Add(ballerId, 1);
                //}
               
            }
            else
            {

                if (FirstTeamBallerOverStackLists != null)
                {
                    if (FirstTeamBallerOverStackLists.ContainsKey(ballerId))
                    {
                        //completeOver = SecondTeamBallerOverStackLists[ballerId];
                        //if(completeOver <= 10)
                        //{

                        //}
                        int lastContainOver = FirstTeamBallerOverStackLists[ballerId];
                        newOver = lastContainOver + 1;
                        FirstTeamBallerOverStackLists[ballerId] = newOver;

                    }
                    else
                    {
                        FirstTeamBallerOverStackLists.Add(ballerId, 1);
                    }

                }
                //else
                //{
                //    FirstTeamBallerOverStackLists.Add(ballerId, 1);
                //}
            }
        }

        public void AddExtraBaller(List<CricketPlayer> cricketPlayerLists , int extraBaller)
        {
            int count = 0;
            for (int i = 0; i < cricketPlayerLists.Count; i++)
            {
                var currentPlayer = cricketPlayerLists[i];

                if (currentPlayer != null && currentPlayer.Title != null && (currentPlayer.Title.ToLower() == "batsman"))
                {
                    if (currentPlayer.Country == FirstTeamName)
                        FirstTeamBallerList.Add(i);
                    else
                        SecondTeamBallerList.Add(i);

                    count++;
                }
                if(count== extraBaller)
                { break; }
            }
        }
    }
}
