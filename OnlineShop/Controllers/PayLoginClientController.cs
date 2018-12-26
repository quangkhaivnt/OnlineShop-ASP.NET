using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using OnlineShop.Models;
using OnlineShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partner = OnlineShop.Models.Partner;

namespace OnlineShop.Controllers
{
    public class PayLoginClientController : Controller
    {
        Services client = new Services();
        [HttpGet]
        // GET: PayLoginClient
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Partner partner)
        {
            if(client.LoginPartner(partner) == false)
            {
                return View(partner);
            }
            else
            {
                Session["Partner"] = client.Find(partner.PartnerAccount).AccountNumber;
                return RedirectToAction("Checkout", "CheckoutClient");
            }
        }

        public ActionResult SaveOrderPay(string shipName,string mobile, string address,string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            var userSession = (UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];

            order.CustomerID = userSession.UserID;
            order.ShipName = shipName;
            order.ShipMobile = mobile;
            order.ShipAddress = address;
            order.ShipEmail = email;

            var id = new OrderDao().Insert(order);
            var cart = (List<CartItem>)Session[CommonConstants.CartSession];
            var detailDao = new OrderDetailDao();
            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductID = item.Product.ID;
                orderDetail.OrderID = id;
                orderDetail.Price = item.Product.Price;
                orderDetail.Quantity = item.Quantity;
                detailDao.Insert(orderDetail);
            }
            return Json(new
            {
                status = true
            });
        }
    }
}