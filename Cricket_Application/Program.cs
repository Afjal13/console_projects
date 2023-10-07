using System.Collections;

namespace Cricket_Application
{
    internal class Program
    {

        static void Main(string[] args)
        {
           
            string? name;
            int age;
            decimal bestscore;
            string? country;
            int n = 0;
            BangladeshTeam team = new BangladeshTeam();
            while (n < 2)
            {
                Console.WriteLine("enter Name: ");
                name = Console.ReadLine();
                Console.WriteLine("enter Age: ");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter bestscore: ");
                bestscore = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("enter country: ");
                country = Console.ReadLine();

                CricketPlayer player = new CricketPlayer(name, age, bestscore, country);
                team.AddPlayer(player);
                n++;
            }
            team.Display();
            Console.ReadKey();
        }
    }
}