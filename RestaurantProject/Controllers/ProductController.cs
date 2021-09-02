using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA_DataAccess;
using OA_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var products = _iProductService.GetAllProduct();
            return Json(products);
        }
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public JsonResult Add([FromBody] Product product)
        {
           var insertedRecords = _iProductService.AddProduct(product);
           return new JsonResult(insertedRecords);
        }
    }
}
