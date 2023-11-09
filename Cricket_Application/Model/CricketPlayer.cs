namespace Cricket_Application.Models
{
    public class CricketPlayer
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public double BestScore { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }

        public CricketPlayer(string? name, int age, double bestScore, string? title, string? country)
        {
            Name = name;
            Age = age;
            BestScore = bestScore;
            Title = title;
            Country = country;
        }
    }
}
