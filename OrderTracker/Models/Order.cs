using System;
using System.Collections.Generic;

namespace OrderTracker.Models
{
    public class Order
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }
        private static List<Order> _instances = new List<Order>();
        public int ID { get; set; }

        public Order(string title, string description, double price, string date)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
            _instances.Add(this);
            ID = _instances.Count;
        }

        public static List<Order> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Order Find(int id)
        {
            return _instances[id - 1];
        }
    }

}