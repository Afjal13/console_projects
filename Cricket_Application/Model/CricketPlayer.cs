namespace Cricket_Application.Models
{
    public class CricketPlayer
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal BestScore { get; set; }
        public string? Country { get; set; }

        public CricketPlayer(string name, int age, decimal bestScore, string country)
        {
            Name = name;
            Age = age;
            BestScore = bestScore;
            Country = country;
        }
    }
}
