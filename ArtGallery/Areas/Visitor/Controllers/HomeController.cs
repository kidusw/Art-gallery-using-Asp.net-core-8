using ArtGallery.DataAccess.Repository.IRepository;
using ArtGallery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtGallery.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult MainPage()
        {
            IEnumerable<Art> artList = _unitOfWork.Art.GetAll(includeProperties: "category");
            return View(artList);
        }

        [Authorize]
        public IActionResult Details(int artid)
        {
            Art art = _unitOfWork.Art.Get(u => u.Id == artid, includeProperties: "category");
            return View(art);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
