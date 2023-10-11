using System;
using System.Collections.Generic;
using Cricket_Application.Models;

namespace Cricket_Application.Teams
{
    public class EnglandTeam
    {
        private List<CricketPlayer> PlayerList = new List<CricketPlayer>();

        public void AddPlayer(CricketPlayer player)
        {
            PlayerList.Add(player);
        }

        public void Display()
        {
            foreach (CricketPlayer player in PlayerList)
            {
                Console.WriteLine($"Name: {player.Name}\nAge: {player.Age}\nBestScore: {player.BestScore}\nCountry: {player.Country}");
                Console.WriteLine();
            }
        }
    }
}
