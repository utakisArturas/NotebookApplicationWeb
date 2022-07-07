using Microsoft.AspNetCore.Mvc;
using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Interfaces
{
    public interface ICategoryRepository 
    {
        public IEnumerable<Category> Index();
        public Category Edit(int? id);
        public Category Edit(Category obj);

        public Category Create(Category obj);
        public void DeletePost(int? id);

    }
}
