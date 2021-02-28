using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = categoryRepository.Entity;
            return View("Categories", categories);
        }

        [HttpGet("CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View("CreateCategory");
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await categoryRepository.CreateAsync(category);
            return RedirectToAction("Categories");
        }

        [HttpGet("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var category = await categoryRepository.GetFirstOrDefaultAsync(new CategoryModel { Ids = new[] { id } });
            return View("UpdateCategory", category);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> Update(Category category)
        {
            await categoryRepository.UpdateAsync(category);
            return RedirectToAction("Categories");
        }

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await categoryRepository.DeleteAsync(new Category { Id = id });
            return RedirectToAction("Categories");
        }
    }
}
