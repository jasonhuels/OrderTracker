using System.Collections.Generic;

namespace OrderTracker.Models
{
    public class Vendor
    {
        private static List<Vendor> _instances = new List<Vendor> { };
        public string Name { get; set; }
        public int ID { get; }
        public List<Order> Orders { get; set; }

        public Category(string name)
        {
            Name = name;
            _instances.Add(this);
            ID = _instances.Count;
            Orders = new List<Order> { };
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<Order> GetAll()
        {
            return _instances;
        }

        public static Category Find(int id)
        {
            return _instances[id - 1];
        }


        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}