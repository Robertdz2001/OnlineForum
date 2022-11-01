namespace Forum.Models.UserModels
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
