﻿using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
   // [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit (int productId)
        {
            Product product = repository.Products.FirstOrDefault (p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit (Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} сохранено", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create ()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete (int productID)
        {
            Product delProduct = repository.DeleteProduct(productID);
            if (delProduct!=null)
            {
                TempData["message"] = string.Format("{0} Выпилен", delProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}