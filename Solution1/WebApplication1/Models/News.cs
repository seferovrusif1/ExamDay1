using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class News : BaseModel
    {
        [Required, MaxLength(32)]
        public string Title { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
