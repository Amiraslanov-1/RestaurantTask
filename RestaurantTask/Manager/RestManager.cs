using Exception;
using Menu;
using Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class RestManager : IRestaurantManager
    {
        //Menu

        List<MenuItem> _items = new List<MenuItem>();
        public List<MenuItem> Menu { get => _items; }
        //Order
        List<Order> _order = new List<Order>();
        public List<Order> Orders { get => _order; }

        // Orders Method
        public List<Order> FilterByData(DateTime first, DateTime last)
        {
            List<Order> orders = new List<Order>();

            var result = _order.FindAll(date => date.OrderDate >= first && date.OrderDate <= last);

            if (result == null)
                throw new ArgumentNull("Null !");

            return result;
        }

        public List<Order> GetOrderByDate(DateTime orderdate)
        {
            List<Order> orders = new List<Order>();

            var result = _order.FindAll(date => date.OrderDate == orderdate);

            if (result == null)
                throw new NotFoundException("Order Not Found !");
            return result;
        }

        public List<Order> FilterOrdersByPrice(double? minPrice, double? maxPrice)
        {

            OrdersItem orders = new OrdersItem();
            if (minPrice == null && maxPrice == null)
                throw new ArgumentNull(" Null ! ");
            if (maxPrice<minPrice)
            {
                throw new ConditionİsNotMetException("Condition is not met !");
            }
            var result = _order.FindAll(order => order.TotalAmount*orders.MenuItem.Price >= minPrice && order.TotalAmount * orders.MenuItem.Price <= maxPrice);

            if (result == null)
                throw new ArgumentNull(" Result Null !");

            return result;

        }

        public Order GetOrderByNo(int? no)
        {
            if (no == null)
                throw new ArgumentNull(" Null !");

            var result = _order.Find(order => order.No == no);
            if (result==null)
            {
                throw new ArgumentNull(" Null !");
            }
            return result;

        }

        public void AddOrder(string order, int? count)
        {
            Order order1 = new Order();
            OrdersItem item = new OrdersItem();

            if (string.IsNullOrWhiteSpace(order))
                throw new ArgumentNull(" Null! ");

            if (count == null)
                throw new ArgumentNull(" The argument cannot be null or 0 !");
            if (count <= 0)
            {
                throw new ArgumentNull(" Count cannot be 0 ! ");
            }
                var result = _items.Find(ordername => ordername.Name == order);
                item.MenuItem = result;
                item.Count = count;
                order1.OrderItems.Add(item);
                _order.Add(order1);

        }

        public void RemoveOrder(int? no)
        {
            if (no == null)
                throw new ArgumentNull(" Null !");


            var result = _order.Find(order => order.No == no);

            if (result != null)
                _order.Remove(result);

            throw new ArgumentNull("Null cannot be deleted !");
        }
        public List<Order> GetAllOrders()
        {
            return _order;
        }

        // Menu Method
        public void RemoveMenuItem(string no)
        {
            if (no == null)
                throw new ArgumentNull(" Null !");

            if (string.IsNullOrWhiteSpace(no))
                throw new ArgumentNull(" Null !");

            var result = _items.Find(x => x.No == no);

            if (result == null)
                throw new ArgumentNull("Null cannot be deleted !");
            else
            {
                _items.Remove(result);
                Console.WriteLine(" Succesfuly Deleted !");

            }


        }


        public void AddItemToMenu(string name, double? price, string category)
        {
            if (_items.Exists(item => item.CategoryFood == category ))
                throw new ItemExistException(" Exist !");

            if (price==null&&price <= 0)
                throw new ArgumentNull("The argument cannot be null or 0");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNull("Null! ");
            if (category.Length<4)
                throw new ConditionİsNotMetException(" Condition Is Not Met ! ");
            MenuItem Menu = new MenuItem(category, name, price);
            _items.Add(Menu);
        }
    

        public void EditMenuItem(string category, string newCategory, double? price)
        {
            MenuItem menuItem = _items.Find(item => item.CategoryFood == category);
            if (string.IsNullOrWhiteSpace(newCategory) && newCategory.Length < 3)
            {
                throw new ConditionİsNotMetException(" Condition Is Not Met ! ");
            }
            if (price == null)
            {
                throw new ArgumentNull("Null !");
            }
            if (menuItem == null)
            {
                throw new ArgumentNull(" Result Is Null !");
            }

            menuItem.CategoryFood = newCategory;
            menuItem.Price = price == null ? menuItem.Price : price;
        }

        public List<MenuItem> GetMenuItemsByCategory(string category)
        {
            List<MenuItem> menus=new List<MenuItem>();

            var result = _items.FindAll(menu => menu.CategoryFood == category);

            if (result == null)
                throw new NotFoundException("Order Not Found !");
            return result;
        }

        public List<MenuItem> FilterMenuByPrice(double? minPrice, double? maxPrice)
        {
            List<MenuItem> menus = new List<MenuItem>();
            if (minPrice == null && maxPrice == null)
                throw new ArgumentNull(" Null ! ");

            var result = _items.FindAll(menu => menu.Price >= minPrice && menu.Price <= maxPrice);

            if (result == null)
                throw new ArgumentNull(" Result  Null !");

            return result;
        }


        public List<MenuItem> SearchTheMenu(string search)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (var menu in _items)
            {

                if (menu.No.Contains(search))
                {
                    menuItems.Add(menu);
                }
                if (menu.Name.Contains(search))
                {
                    menuItems.Add(menu);
                }
                if (menu.CategoryFood.Contains(search))
                {
                    menuItems.Add(menu);
                }
                if (menu.Price.ToString().Contains(search))
                {
                    menuItems.Add(menu);
                }
                

            }
            return menuItems;

        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _items;
        }
    }
}
