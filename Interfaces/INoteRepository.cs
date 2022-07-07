using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Interfaces
{
    public interface INoteRepository
    {
        public Note Create(Note obj, IFormFile Image);
        public IEnumerable<Note> Index();
        public Note GetImageById(int? id);
        public Category GetCategoryById(int? id);

    }
}
