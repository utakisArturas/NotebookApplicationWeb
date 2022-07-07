using NotebookApplicationWeb.Data;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _database;

        public NoteRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public Note Create(Note obj, IFormFile Image)
        {
            using var memoryStream = new MemoryStream();
            Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var noteToUpload = new Note();
            noteToUpload.Title = obj.Title;
            noteToUpload.Description = obj.Description;
            noteToUpload.ImageBytes = imageBytes;
            noteToUpload.Category = GetCategory(obj.IdForQuery);
            _database.Notes.Add(noteToUpload);
            _database.SaveChanges();
            return noteToUpload;
        }
        public Category GetCategory(int? id)
        {
            var category = _database.Categories.Find(id);
            return category;
        }

        public Category GetCategoryById(int? id)
        {
            var category = _database.Categories.Find(id);
            return category;
        }

        public Note GetImageById(int? id)
        {
            var note = _database.Notes.Find(id);
            return note;
        }

        public IEnumerable<Note> Index()
        {
            IEnumerable<Note> objectNoteList = _database.Notes;
            return objectNoteList;
        }

    }
}
