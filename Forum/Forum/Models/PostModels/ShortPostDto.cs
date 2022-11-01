namespace Forum.Models.PostModels
{
    public class ShortPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AnswerCount { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
