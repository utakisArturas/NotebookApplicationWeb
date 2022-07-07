using Microsoft.AspNetCore.Mvc;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _categoryRepository.Edit(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            _categoryRepository.Edit(obj);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.Index());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _categoryRepository.Create(obj);
            return RedirectToAction("Index");
        }
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _categoryRepository.DeletePost(id);

            return RedirectToAction("Index");
        }

    }
}
