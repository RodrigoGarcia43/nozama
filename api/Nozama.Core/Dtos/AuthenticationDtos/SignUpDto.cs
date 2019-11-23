namespace Nozama.Core.Dtos
{
    public class SignUpDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double Balance { get; set; }
    }
}