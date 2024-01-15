using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.ViewModels.NewsVMs;
using WebApplication1.Context;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        ExamDay1DBContext _dBContext { get; set; }

        public HomeController(ExamDay1DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<NewsListItemVM> vmList = _dBContext.News.Select(s => new NewsListItemVM
            {
                Id = s.Id,
                Author = s.Author,
                Title = s.Title,
                ImagePath = s.ImagePath,
                IsDelete = s.IsDelete,
            }).ToList();
            return View(vmList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateVM vm)
        {
            await _dBContext.News.AddAsync(new Models.News
            {
                Author = vm.Author,
                Title = vm.Title,
                ImagePath = vm.ImagePath,
                Description = vm.Description,
                IsDelete = false,
                CreatedTime = DateTime.UtcNow
            }) ;
            await _dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _dBContext.News.FindAsync(id);
            return View(new NewsUpdateVm
            {
                Author = vm.Author,
                Title = vm.Title,
                ImagePath = vm.ImagePath,
                Description = vm.Description,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, NewsUpdateVm vm)
        {
            var data = await _dBContext.News.FindAsync(id);
            if (data == null) throw new Exception("Not Found");
            data.Author = vm.Author;
            data.Title = vm.Title;
            data.ImagePath = vm.ImagePath;
            data.Description = vm.Description;
            data.IsDelete = false;
            await _dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _dBContext.News.FindAsync(id);
            _dBContext.News.Remove(data);
            _dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var data = await _dBContext.News.FindAsync(id);
            data.IsDelete = true;
            _dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ReverseSoftDelete(int id)
        {
            var data = await _dBContext.News.FindAsync(id);
            data.IsDelete = false;
            _dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
