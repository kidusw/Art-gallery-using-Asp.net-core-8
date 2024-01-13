using ArtGallery.DataAccess.Repository.IRepository;
using ArtGallery.Models;
using ArtGallery.Models.ViewModel;
using ArtGallery.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtGallery.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ArtController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ArtController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Art> objCateogryList = _unitOfWork.Art.GetAll(includeProperties: "category").ToList();

            return View(objCateogryList);
        }
        public IActionResult Upsert(int? id)
        {

            ArtVM artVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            ),
                Art = new Art()
            };
            if (id == null || id == 0)
            {
                return View(artVM);
            }
            else
            {
                artVM.Art = _unitOfWork.Art.Get(u => u.Id == id);
                return View(artVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ArtVM artVM, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string artPath = Path.Combine(wwwRootPath, @"Images\Art");

                    if (!string.IsNullOrEmpty(artVM.Art.Imageurl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, artVM.Art.Imageurl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(artPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    artVM.Art.Imageurl = @"\Images\Art\" + fileName;
                }
                if (artVM.Art.Id == 0)
                {
                    _unitOfWork.Art.Add(artVM.Art);
                    TempData["success"] = "category created successfully";
                }
                else
                {
                    _unitOfWork.Art.Update(artVM.Art);
                    TempData["success"] = "category Updated successfully";
                }

                _unitOfWork.Save();


                return RedirectToAction("Index");
            }
            else
            {
                artVM.CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            );
                return View(artVM);
            }


        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Art> objCateogryList = _unitOfWork.Art.GetAll(includeProperties: "category").ToList();
            return Json(new { data = objCateogryList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Art.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });

            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.Imageurl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Art.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
