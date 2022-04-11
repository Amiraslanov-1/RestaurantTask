using Menu;
using Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IRestaurantManager
    {
        //List
        public List<MenuItem> Menu { get; }
        public List<Order> Orders { get; }



        //Orders method
        public List<Order> FilterByData(DateTime first, DateTime last);
        public List<Order> GetOrderByDate(DateTime orderDate);
        public List<Order> FilterOrdersByPrice(double? minPrice, double? maxPrice);
        public Order GetOrderByNo(int? no);
        public void AddOrder(string order, int? count);
        public void RemoveOrder(int? no);
        public List<Order> GetAllOrders();

        //Menu method
        public void RemoveMenuItem(string no);
        public void AddItemToMenu(string name, double? price, string category);
        public void EditMenuItem(string category, string newCategory, double? price);
        public List<MenuItem> GetMenuItemsByCategory(string category);
        public List<MenuItem> FilterMenuByPrice(double? minPrice, double? maxPrice);
        public List<MenuItem> SearchTheMenu(string search);
        public List<MenuItem> GetAllMenuItems();
    }
}
