using Microsoft.AspNetCore.Mvc;
using OA_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Controllers
{
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
    }
}
