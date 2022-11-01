using Forum.Entities;

namespace Forum.Models.UserModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
