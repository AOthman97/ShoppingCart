using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.DataAccess.ViewModels;
using ShoppingCart.Models;

namespace ShoppingCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            CategoryViewModel categoryViewModel = new()
            {
                Categories = _unitOfWork.Category.GetAll()
            };
            return View(categoryViewModel);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/CreateUpdate/5
        public ActionResult CreateUpdate(int? id)
        {
            CategoryViewModel viewModel = new();

            if(id == null || id == 0)
            {
                return View(viewModel);
            }
            else
            {
                Category? category = _unitOfWork.Category.GetT(x => x.Id == id);

                if (category != null)
                    viewModel.Category = category;
                else
                    return NotFound();

                if (viewModel.Category == null)
                    return NotFound();
                else
                    return View(viewModel);
            }
        }

        // POST: CategoryController/CreateUpdate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdate(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save
                    if(viewModel.Category.Id == 0)
                    {
                        _unitOfWork.Category.Add(viewModel.Category);
                        TempData["Success"] = "Created Successfully!";
                    }
                    else // Update
                    {
                        _unitOfWork.Category.Update(viewModel.Category);
                        TempData["Success"] = "Updated Successfully!";
                    }

                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == 0 || id == null)
                return NotFound();

            var category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (category == null)
                return NotFound();

            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}