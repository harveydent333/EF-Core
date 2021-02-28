using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductController(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await productRepository.GetAsync(new ProductModel { IncludeCategory = true });
            return View("Products", products);
        }

        [HttpGet("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await categoryRepository.Entity.ToListAsync();
            return View("CreateProduct");
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await productRepository.CreateAsync(product);
            return RedirectToAction("Products");
        }

        [HttpGet("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.Categories = await categoryRepository.Entity.ToListAsync();
            var product = await productRepository.GetFirstOrDefaultAsync(new ProductModel { Ids = new[] { id } });
            return View("UpdateProduct", product);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> Update(Product product)
        {
            await productRepository.UpdateAsync(product);
            return RedirectToAction("Products");
        }

        [HttpGet("UpdateAllProducts")]
        public async Task<IActionResult> UpdateAllProducts()
        {
            var products = productRepository.Entity;
            return View("UpdateAll", products);
        }

        [HttpGet("UpdateSelected")]
        public async Task<IActionResult> UpdateSelected(int[] ids)
        {
            if (ids.Length == 0)
            {
                return RedirectToAction("Products");
            }

            ViewBag.Categories = await categoryRepository.Entity.ToListAsync();
            var products = await productRepository.GetAsync(new ProductModel { Ids = ids });
            return View("ManyUpdates", products);
        }

        [HttpPost("UpdateAllProducts")]
        public async Task<IActionResult> UpdateAllProducts(IEnumerable<Product> products)
        {
            await productRepository.UpdateAsync(products);
            return RedirectToAction("Products");
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productRepository.DeleteAsync(new Product { Id = id });
            return RedirectToAction("Products");
        }

        [HttpPost("DeleteAllProducts")]
        public async Task<IActionResult> DeleteAllProduct()
        {
            return RedirectToAction("Products");
        }

        [HttpPost("DeleteSelected")]
        public async Task<IActionResult> DeleteSelected(int[] ids)
        {
            var products = await productRepository.GetAsync(new ProductModel { Ids = ids });
            await productRepository.DeleteAsync(products);
            return RedirectToAction("Products");
        }
    }
}
