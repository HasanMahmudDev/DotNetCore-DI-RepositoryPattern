using Microsoft.AspNetCore.Mvc;
using MyApp.Interfaces;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() => View(_repo.GetAll());
        // GET: Product/Create
        public IActionResult Create() => View();

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _repo.GetById(id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }
    }
}
