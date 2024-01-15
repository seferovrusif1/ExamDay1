namespace WebApplication1.Areas.Admin.ViewModels.NewsVMs
{
    public class NewsListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
        public bool IsDelete { get; set; }

    }
}
