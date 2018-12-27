using Model.Dao;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CheckoutClientController : Controller
    {
        Services client = new Services();
        [HttpGet]
        // GET: CheckoutClient
        public ActionResult Checkout()
        {
            var orderID = new OrderDao().Find();
            var total = new OrderDetailDao().Find(orderID);

            ViewBag.orderID = orderID;
            ViewBag.total = total;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Transaction transaction)
        {

            try
            {
                transaction.SenderAccountNumber = Convert.ToInt64(Session["Partner"].ToString());
                transaction.ReceiverAccountNumber = 3;
                transaction.Status = 1;
                transaction.Type = 1;
                transaction.CreatedAt = DateTime.Now;
                transaction.UpdatedAt = DateTime.Now;
                var orderID = new OrderDao().Find();
                //long paypalId = 2;
                if (client.Transaction(transaction))
                {
                    var orderTrue = new OrderDao().UpdateStatus(orderID);
                    Session[OnlineShop.Common.CommonConstants.CartSession] = null;
                    return Redirect("/hoan-thanh");
                }
                else
                {
                    return Redirect("/loi-thanh-toan");
                }
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

        }
    }
}