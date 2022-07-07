using Microsoft.AspNetCore.Mvc;
using NotebookApplicationWeb.Data;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;
using System.Collections.Generic;

namespace NotebookApplicationWeb.Repositories
{
    public class CategoryRepository :ICategoryRepository
    {
        private readonly ApplicationDbContext _database;

        public CategoryRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public Category Create(Category obj)
        {
            _database.Categories.Add(obj);
            _database.SaveChanges();
            return obj;
        }

        public void DeletePost(int? id)
        {
            var category = _database.Categories.Find(id);
            _database.Categories.Remove(category);
            _database.SaveChanges();
        }

        public Category Edit(int? id)
        {
            var category = _database.Categories.Find(id);
            return category;
           
        }

        public Category Edit(Category obj)
        {
            _database.Categories.Update(obj);
            _database.SaveChanges();
            return obj;
        }

        public IEnumerable<Category> Index()
        {
           IEnumerable<Category> objectCategoryList = _database.Categories;
           return objectCategoryList;
        }
    }
}
