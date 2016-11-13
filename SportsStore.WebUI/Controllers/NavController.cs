using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/

        private IProductRepository repository;
        public int PageSize = 4;

        public NavController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public PartialViewResult Menu (string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products.Select(p=> p.Category).Distinct().OrderBy(x => x).ToList();
            return PartialView(categories);
        }

    }
}
