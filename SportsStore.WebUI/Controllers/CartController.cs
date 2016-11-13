using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        public ViewResult Index (Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = cart,
                    ReturnUrl = returnUrl
                });
        }

        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart (Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product !=null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shipingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Карзина пуста. Идите нахуй!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shipingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shipingDetails);
            }
        }
        public ViewResult Checkout ()
        {
            return View(new ShippingDetails());
        }

    }
}
