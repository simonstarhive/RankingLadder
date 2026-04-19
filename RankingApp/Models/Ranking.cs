namespace RankingApp.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public int Rank { get; set; }

        public string Name { get; set; }
        public RankingCategory Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}