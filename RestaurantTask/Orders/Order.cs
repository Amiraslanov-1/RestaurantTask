using System;
using System.Collections;
using System.Collections.Generic;
namespace Orders
{
    public class Order:IEnumerable
    {
        public  List<OrdersItem> OrderItems =new List<OrdersItem>();
        static int _no;
        public int No { get; }

        public double? TotalAmount { get; set; } = 0;
        public DateTime OrderDate{ get; }
        
       
        public Order()
        {
            _no++;
            No = _no;
            
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in OrderItems )
            {
                yield return item.MenuItem.No;
                yield return item.MenuItem.Name;
                yield return item.MenuItem.CategoryFood;
                yield return item.MenuItem.Price;
            }
        }
    }
}
