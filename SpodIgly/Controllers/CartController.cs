using SpodIgly.DAL;
using SpodIgly.Infrastructure;
using SpodIgly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpodIgly.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();

        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
        }

        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemCount();
        }

        public ActionResult RemoveFromCart(int albumId)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(albumId);
            int cartItemsCount = shoppingCartManager.GetCartItemCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = albumId,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };
            return Json(result);
        }
    }
}