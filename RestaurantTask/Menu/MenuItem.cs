using System;
using System.Collections.Generic;

namespace Menu
{
    public class MenuItem
    {
        static int _noFood=100;
        public string No { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string CategoryFood  { get; set; }
        public MenuItem(string category,string name ,double? price )
        {
            this.CategoryFood = category;
            this.Name = name;
            this.Price = price;
            _noFood++;
            No = CategoryFood.Substring(0, 2) + _noFood++;

        }

    }
}
