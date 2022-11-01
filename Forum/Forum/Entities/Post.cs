namespace Forum.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AnswerCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0; 
        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
