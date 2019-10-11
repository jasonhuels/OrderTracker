using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace OrderTracker.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet("/vendors/{id}/orders/new")]
        public ActionResult New(int id)
        {
            Vendor vendor = Vendor.Find(id);
            return View(vendor);
        }

        [HttpGet("/vendors/{vendorID}/orders/{orderID}")]
        public ActionResult Show(int vendorID, int orderID)
        {
            Order order = Order.Find(orderID);
            Vendor vendor = Vendor.Find(vendorID);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("order", order);
            model.Add("vendor", vendor);
            return View(model);
        }

        [HttpPost("/orders/delete")]
        public ActionResult DeleteAll()
        {
            Order.ClearAll();
            return View();
        }
    }
}