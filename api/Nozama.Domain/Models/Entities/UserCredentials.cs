using System.Collections.Generic;
using Nozama.Domain.Models.Aggregates;

namespace Nozama.Domain.Models.Entities
{
    public class UserCredentials
    {
        public string Id { get; set; }

        public User User { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}