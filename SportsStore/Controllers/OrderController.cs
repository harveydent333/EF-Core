using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Entities;
using SportsStore.Repositories.Interfaces;
using SportsStore.Repositories.Models;

namespace SportsStore.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public OrderController(
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var orders = await orderRepository.GetAsync(new OrderModel { IncludeLines = true });
            return View("Orders", orders);
        }

        [HttpGet("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            var products = await productRepository.GetAsync(new ProductModel { IncludeCategory = true });
            var lines = new List<OrderLine>();
            foreach (var product in products)
            {
                lines.Add(new OrderLine { Product = product, ProductId = product.Id, Quantity = 0 });
            }

            ViewBag.Lines = lines;
            return View("CreateOrder");
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await orderRepository.CreateAsync(order);
            return RedirectToAction("Orders");
        }

        [HttpGet("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var products = await productRepository.GetAsync(new ProductModel { IncludeCategory = true });
            var order = await orderRepository.GetFirstOrDefaultAsync(new OrderModel { Ids = new int[] { id }, IncludeLines = true });

            Dictionary<int?, OrderLine> linesMap = order.Lines?.ToDictionary(o => o.ProductId);

            var lines = new List<OrderLine>();
            foreach (var product in products)
            {
                if (linesMap.ContainsKey(product.Id))
                {
                    lines.Add(linesMap[product.Id]);
                }
                else
                {
                    lines.Add(new OrderLine { Product = product, ProductId = product.Id, Quantity = 0 });
                }
            }

            ViewBag.Lines = lines;
            return View("UpdateOrder", order);
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> Update(Order order)
        {
            order.Lines = order.Lines.Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToList();
            await orderRepository.UpdateAsync(order);
            return RedirectToAction("Orders");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await orderRepository.DeleteAsync(new Order { Id = id });
            return RedirectToAction("Orders");
        }
    }
}
