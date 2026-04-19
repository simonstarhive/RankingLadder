using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace RankingApp.Models
{
    public class User : IdentityUser<int>
    {
        public int Ucfid { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; } = Role.USER;

        public ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();
    }
}