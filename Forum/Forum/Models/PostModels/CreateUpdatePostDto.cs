using System.ComponentModel.DataAnnotations;

namespace Forum.Models.PostModels
{
    public class CreateUpdatePostDto
    {
        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
