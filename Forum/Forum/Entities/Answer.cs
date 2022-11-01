namespace Forum.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
