namespace BMIWebApi.Models
{
    public class User
    {
        public string NickName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EmailConfirmed { get; set; }
    }
}
