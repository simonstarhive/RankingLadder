namespace RankingApp.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }
        public string ScoreValue { get; set; } // rename if your API uses "score"
        public string Gender { get; set; }
    }
}