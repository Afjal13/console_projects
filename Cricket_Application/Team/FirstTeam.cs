using System;
using System.Collections.Generic;
using Cricket_Application.Models;

namespace Cricket_Application.Teams
{
    public class FirstTeam
    {
        private List<CricketPlayer> _Players = new List<CricketPlayer>();

        public void AddPlayer(CricketPlayer player)
        {
            _Players.Add(player);
        }

        public void Display()
        {
            foreach (CricketPlayer player in _Players)
            {
                Console.WriteLine($"Name: {player.Name}\nAge: {player.Age}\nBestScore: {player.BestScore}\nCountry: {player.Country}");
                Console.WriteLine();
            }
        }

        public List<CricketPlayer> GetPlayers()
        {
            return _Players;
        }
    }
}
