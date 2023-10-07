 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Application
{
    internal class BangladeshTeam
    {
        List<CricketPlayer> PlayerLists =new List<CricketPlayer>();
        public void AddPlayer(CricketPlayer player)
        {
            PlayerLists.Add(player);
        }

        public void Display()
        {
            foreach (CricketPlayer player in PlayerLists)
            {
                Console.WriteLine($"Name: {player.Name}\nAge: {player.Age}\nBestScore: {player.BestScore}\nCountry: {player.Country}");
               
            }
        }
    }
}
