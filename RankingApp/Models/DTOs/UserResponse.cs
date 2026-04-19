namespace RankingApp.Models.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int Ucfid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public UserResponse(int id, int ucfid, string name, string email, Gender gender)
        {
            Id = id;
            Ucfid = ucfid;
            Name = name;
            Email = email;
            Gender = gender.ToString();
        }
    }
}