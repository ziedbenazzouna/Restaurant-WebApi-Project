using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Controllers
{
    public class ProductTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
            => await _context.Products.ToArrayAsync();

        [HttpPost]
        public async Task<Product> Add ([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

    }
}
