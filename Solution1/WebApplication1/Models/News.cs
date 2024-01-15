namespace WebApplication1.Models
{
    public class News : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
    }
}
