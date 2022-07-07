using Microsoft.AspNetCore.Mvc;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Controllers
{
    public class NoteController : Controller
    {
        private INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {

            return View(_noteRepository.Index());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Note obj, IFormFile Image)
        {
            _noteRepository.Create(obj, Image);
            return RedirectToAction("Index");

        }
        public IActionResult ShowImage(int? id)
        {
            var image =  _noteRepository.GetImageById(id);
            return File(image.ImageBytes,$"image/jpg");
        }
        public IActionResult ShowCategoryIdAndName(int? id)
        {
            _noteRepository.GetCategoryById(id);
            return RedirectToAction("Index");
        }

    }
}
