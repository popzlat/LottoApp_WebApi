namespace Models
{
    public class UserModel
    {

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Balance { get; set; }
        public byte Role { get; set; }
        public string Token { get; set; }

    }
}
