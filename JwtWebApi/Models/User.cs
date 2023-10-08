namespace JwtWebApi.Models
{
    public class User
    {
        public string Username { get; set; }
        public byte[] PasswordHarsh { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
