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
        Start:
            {
                Console.Write("\n\n\t\t\t1.Bangladesh  2. England  0.Cancel");
                Console.Write("\n\t==================================================================");
                Console.Write("\nSelect Country:");
                int selectCountry = Convert.ToInt32(Console.ReadLine());
                switch (selectCountry)
                {
                    case 0:
                        return;
                    case 1:
                        {
                            goto Bangladesh;
                        }
                    case 2:
                        {
                            goto England;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input!");
                            goto Start;
                        }

                }
            }


        Bangladesh:
            {
                BangladeshTeam team = new BangladeshTeam();

            AddBngPlayer:
                {
                    Console.Write("Enter total number of Player(0<input<=11): ");
                    bool isTrue = int.TryParse(Console.ReadLine(), out int totalPlayers);
                    if (isTrue)
                    {
                        if (totalPlayers > 0)
                        {
                            do
                            {
                                Console.WriteLine("enter Name: ");
                                name = Console.ReadLine();
                                Console.WriteLine("enter Age: ");
                                age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("enter bestscore: ");
                                bestscore = Convert.ToDecimal(Console.ReadLine());
                                CricketPlayer player = new CricketPlayer(name, age, bestscore, "Bangladesh");
                                team.AddPlayer(player);
                            } while (totalPlayers > 1 & totalPlayers <=11);

                            team.Display();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            goto AddBngPlayer;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        goto AddBngPlayer;
                    }
                }
            }
        England:
            {
                Console.WriteLine("Nothing!");
                goto Start;
            }
        }
    }
}