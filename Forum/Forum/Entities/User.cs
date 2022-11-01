namespace Forum.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Post> Posts {get;set;}
        public virtual List<Answer> Answers {get;set;}
        public virtual List<Comment> Comments {get;set;}
    }
}
