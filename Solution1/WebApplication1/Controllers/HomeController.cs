using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ExamDay1DBContext _dbContext { get; }

        public HomeController(ExamDay1DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<NewsListItemVM> vmList = _dbContext.News.Where(x=>x.IsDelete==false).OrderByDescending(d=>d.CreatedTime).Take(3).Select(s=>new NewsListItemVM 
            { 
                Author=s.Author,
                Description=s.Description,
                Title=s.Title,
                ImagePath=s.ImagePath
            }).ToList();
            return View(vmList);
        }
    }
}