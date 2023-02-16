using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Models.Product;
using Shopping.Service.Product;

namespace Shopping.Controllers
{
    [Authorize(Roles = "admin")]
    public class DashBoardController : Controller
    {
        private readonly IProductService _product;
        private readonly DatabaseContext _context;
        public DashBoardController(IProductService product, DatabaseContext context)
        {
            this._product = product;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Product()
        {
            var product = _product.GetAllProducts();
            return View(product);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var mode = _product.GetProductById(id);
            return View(mode);
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel product, IFormFile image)
        {
            await _product.AddProduct(product, image);
            return RedirectToAction("Product", "DashBoard");
        }
        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            var mode = _product.GetProductById(id);
            return View(mode);
        }
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel product, IFormFile image)
        {
            await _product.UpdateProduct(product, image);
            return RedirectToAction("Product", "DashBoard");
        }

        public IActionResult ProductDelete(int id)
        {
            _product.DeleteProduct(id);
            return RedirectToAction("Product");
        }
        //Nguyen
    }
}
