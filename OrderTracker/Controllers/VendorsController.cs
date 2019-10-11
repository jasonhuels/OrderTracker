using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using OrderTracker.Models;

namespace OrderTracker.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> myVendors = Vendor.GetAll();
            return View(myVendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string name, string description)
        {
            Vendor vendor = new Vendor(name, description);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor vendor = Vendor.Find(id);
            List<Order> orders = vendor.Orders;
            model.Add("vendor", vendor);
            model.Add("orders", orders);
            return View(model);
        }

        [HttpPost("/vendors/{vendorID}/orders")]
        public ActionResult Create(int vendorID, string orderTitle, string orderDescription, double orderPrice, string orderDate)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor myVendor = Vendor.Find(vendorID);
            Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
            myVendor.AddOrder(newOrder);
            List<Order> vendorOrders = myVendor.Orders;
            model.Add("orders", vendorOrders);
            model.Add("vendor", myVendor);
            return View("Show", model);
        }
    }
}