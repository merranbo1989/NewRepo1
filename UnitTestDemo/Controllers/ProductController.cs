using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Models;

namespace UnitTestDemo.Controllers
{
    public class ProductController : Controller
    {
        public IList<Product> prod = new List<Product>();

        //prod = 
        Product product = new Product(1, "VCR");
       
        public IActionResult Index()
        {
            CreateProducts();
            return View(prod);
        }

        private void CreateProducts()
        {
            prod.Add(product);
            product = new Product(2, "Television");
            prod.Add(product);
            product = new Product(3, "Gaming Console");
            prod.Add(product);
        }

        public ActionResult Details(int id)
        {
            if(id < 1)
            {
                return RedirectToAction("Index");
            }
            CreateProducts();
            var product = prod.Where(x=>x.Id==id);
           var name = product.FirstOrDefault()?.Name;
            return View("Details", name);
        }

    }
}
