using System;
using System.Collections.Generic;
using System.Text;
using Exception;
using Manager;
using Orders;
namespace RestaurantTask
{
    public class MethodForMenu
    {
        RestManager _restaurant = new RestManager();
        public void ShowMenu()
        {
            Console.WriteLine("1.Menu ");
            Console.WriteLine("2.Orders");
            Console.WriteLine("3.Exit ");
            Console.WriteLine("Enter Your Choice :");
        }
        public void MenuItem()
        {
            string choiceMenu;
            do
            {
                Console.WriteLine("1 Add a new item  ");
                Console.WriteLine("2 Edit Item  ");
                Console.WriteLine("3 Delete Item ");
                Console.WriteLine("4 Show All Item  ");
                Console.WriteLine("5 Show menu items by category ");
                Console.WriteLine("6 Filter By Price");
                Console.WriteLine("7 Search Item");
                Console.WriteLine("0. Return to previous menu\n");

                Console.WriteLine("Enter Your Choice :");
                choiceMenu = Console.ReadLine();
                switch (choiceMenu)
                {
                    case "1":

                        Console.WriteLine("Enter Item Name :");
                        string name = Console.ReadLine();

                        while (!checkName(name))
                        {
                            Console.WriteLine("Enter Correctly :");
                            name = Console.ReadLine();
                        }

                        Console.WriteLine("Enter Item Price :");

                        double price;
                        string priceStr = Console.ReadLine();
                        bool check = double.TryParse(priceStr, out price);
                        while (!check)
                        {
                            Console.WriteLine("Enter Correctly :");
                            priceStr = Console.ReadLine();
                            check = double.TryParse(priceStr, out price);
                        }

                        Console.WriteLine("Enter Category Name :");
                        string category = Console.ReadLine();

                        while (!checkName(category))
                        {
                            Console.WriteLine("Enter Correctly :");
                            category = Console.ReadLine();
                        }

                        try
                        {
                            _restaurant.AddItemToMenu(name, price, category);
                        }
                        catch (ItemExistException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "2":

                        Console.WriteLine("Enter Category Name :");
                        string searchCtgr = Console.ReadLine();

                        while (!checkName(searchCtgr))
                        {
                            Console.WriteLine("Enter Correctly :");
                            searchCtgr = Console.ReadLine();
                        }
                        Console.WriteLine("Enter New Category Name :");
                        string newCtgr = Console.ReadLine();

                        while (!checkName(newCtgr))
                        {
                            Console.WriteLine("Enter Correctly :");
                            newCtgr = Console.ReadLine();
                        }

                        Console.WriteLine("Enter New Item Price :");

                        double newPrice;
                        string newPriceStr = Console.ReadLine();
                        bool checkNew = double.TryParse(newPriceStr, out newPrice);
                        while (!checkNew)
                        {
                            Console.WriteLine("Enter Correctly :");
                            newPriceStr = Console.ReadLine();
                            checkNew = double.TryParse(newPriceStr, out newPrice);
                        }

                        _restaurant.EditMenuItem(searchCtgr, newCtgr, newPrice);

                        break;
                    case "3":

                        //Burda No nun try catcha saldim yoxladim yoxlayirdim )
                        Console.WriteLine(" Enter No : ");
                        string no = Console.ReadLine();
                        try
                        {
                            _restaurant.RemoveMenuItem(no);
                        }
                        catch (ArgumentNull ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "4":
                        foreach (var item in _restaurant.GetAllMenuItems())
                        {
                            Console.WriteLine("-----------------------------------------");

                            Console.WriteLine($"No: {item.No}\nCategory: {item.CategoryFood} \nPrice: {item.Price}  ");

                            Console.WriteLine("----------------------------------------");
                        }
                        break;
                    case "5":
                        foreach (var item in _restaurant.GetAllMenuItems())
                        {
                            Console.WriteLine($"- {item.CategoryFood}");
                        }

                        Console.WriteLine("Enter Category Name :");
                        string searchCategory = Console.ReadLine();

                        while (!checkName(searchCategory))
                        {
                            Console.WriteLine("Enter Correctly :");
                            searchCategory = Console.ReadLine();
                        }
                        foreach (var item in _restaurant.SearchTheMenu(searchCategory))
                        {
                            Console.WriteLine($"No - {item.No}\nName - {item.Name}\nCategory - {item.CategoryFood}\nPrice - {item.Price}\n");

                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter Min Price :");
                        double minPrice;
                        string minPriceStr = Console.ReadLine();
                        bool minCheck = double.TryParse(minPriceStr, out minPrice);
                        while (!minCheck)
                        {
                            Console.WriteLine("Enter Correctly :");
                            minPriceStr = Console.ReadLine();
                            minCheck = double.TryParse(minPriceStr, out minPrice);
                        }
                        Console.WriteLine("Enter Max Price :");
                        double maxPrice;
                        string maxPriceStr = Console.ReadLine();
                        bool maxCheck = double.TryParse(maxPriceStr, out maxPrice);
                        while (!maxCheck)
                        {
                            Console.WriteLine("Enter Correctly :");
                            maxPriceStr = Console.ReadLine();
                            maxCheck = double.TryParse(maxPriceStr, out maxPrice);
                        }

                        foreach (var item in _restaurant.FilterMenuByPrice(minPrice, maxPrice))
                        {
                            Console.WriteLine($"No - {item.No}\nName - {item.Name}\nCategory - {item.CategoryFood}\nPrice - {item.Price}\n");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Enter A Search Term");
                        string STM = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(STM))
                        {
                            Console.WriteLine("Enter Correctly :");
                            STM = Console.ReadLine();
                        }
                        foreach (var item in _restaurant.SearchTheMenu(STM))
                        {
                            Console.WriteLine($"No - {item.No}\nName - {item.Name}\nCategory - {item.CategoryFood}\nPrice - {item.Price}\n");
                        }
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while ("0" != choiceMenu);
        }

        public void OrderItem()
        {
            string Orders;
            do
            {

                Console.WriteLine("1 Add Order ");
                Console.WriteLine("2 Order Cancellation");
                Console.WriteLine("3 Show All Orders");
                Console.WriteLine("4 Filter By Date");
                Console.WriteLine("5 Filter By Price");
                Console.WriteLine("6 Show Order By Date");
                Console.WriteLine("7 Search By No");
                Console.WriteLine("0. Return to previous menu\n");

                Console.WriteLine("Enter Your Choice : ");
                Orders = Console.ReadLine();
                switch (Orders)
                {
                    case "1":

                        Console.WriteLine("Enter Item Name :");
                        string name = Console.ReadLine();

                        while (!checkName(name))
                        {
                            Console.WriteLine("Enter Correctly :");
                            name = Console.ReadLine();
                        }
                        Console.WriteLine("Enter Count :");
                        int count;
                        string countStr = Console.ReadLine();
                        bool check = int.TryParse(countStr, out count);
                        while (!check)
                        {
                            Console.WriteLine("Enter Correctly :");
                            countStr = Console.ReadLine();
                            check = int.TryParse(countStr, out count);
                        }
                        try
                        {
                            _restaurant.AddOrder(name, count);

                        }
                        catch (ArgumentNull ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "2":
                        int no;
                        string noStr = Console.ReadLine();
                        bool checkNo = int.TryParse(noStr, out no);
                        while (!checkNo)
                        {
                            Console.WriteLine("Enter Correctly :");
                            noStr = Console.ReadLine();
                            checkNo = int.TryParse(noStr, out no);
                        }
                        try
                        {
                            _restaurant.RemoveOrder(no);

                        }
                        catch (ArgumentNull ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        foreach (var item in _restaurant.GetAllOrders())
                        {
                            foreach (var orderItem in item.OrderItems)
                            {
                                Console.WriteLine($"No - {orderItem.MenuItem.No}\nName - {orderItem.MenuItem.Name}\nCategory - {orderItem.MenuItem.CategoryFood}\nPrice - {orderItem.MenuItem.Price}\nCount - {orderItem.Count}");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter First Date :");
                        DateTime firstDate;
                        string firstdateStr = Console.ReadLine();
                        bool checkFirstDate = DateTime.TryParse(firstdateStr, out firstDate);
                        while (!checkFirstDate)
                        {
                            Console.WriteLine("Enter Date correctly ! Example - (2022.04.11)");
                            firstdateStr = Console.ReadLine();
                            checkFirstDate = DateTime.TryParse(firstdateStr, out firstDate);
                        }

                        Console.WriteLine("Enter Last Date :");
                        DateTime lastDate;
                        string lastDateStr = Console.ReadLine();
                        bool checkLastDate = DateTime.TryParse(lastDateStr, out lastDate);
                        while (!checkLastDate)
                        {
                            Console.WriteLine("Enter Date correctly ! Example - (2022.11.05)");
                            lastDateStr = Console.ReadLine();
                            checkLastDate = DateTime.TryParse(lastDateStr, out lastDate);
                        }

                        foreach (Order item in _restaurant.FilterByData(firstDate, lastDate))
                        {
                            foreach (OrdersItem orderItem in item.OrderItems)
                            {
                                Console.WriteLine($"No - {orderItem.MenuItem.No}\nName - {orderItem.MenuItem.Name}\nCategory - {orderItem.MenuItem.CategoryFood}\nPrice - {orderItem.MenuItem.Price}\nCount - {orderItem.Count}");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter Min Price :");
                        double minPrice;
                        string minPriceStr = Console.ReadLine();
                        bool minCheck = double.TryParse(minPriceStr, out minPrice);
                        while (!minCheck)
                        {
                            Console.WriteLine("Enter Correctly :");
                            minPriceStr = Console.ReadLine();
                            minCheck = double.TryParse(minPriceStr, out minPrice);
                        }
                        Console.WriteLine("Enter Max Price :");
                        double maxPrice;
                        string maxPriceStr = Console.ReadLine();
                        bool maxCheck = double.TryParse(maxPriceStr, out maxPrice);
                        while (!maxCheck)
                        {
                            Console.WriteLine("Enter Correctly :");
                            maxPriceStr = Console.ReadLine();
                            maxCheck = double.TryParse(maxPriceStr, out maxPrice);
                        }

                        try
                        {
                            foreach (var item in _restaurant.FilterOrdersByPrice(minPrice, maxPrice))
                            {
                                foreach (var orderItem in item.OrderItems)
                                {
                                    Console.WriteLine($"No - {orderItem.MenuItem.No}\nName - {orderItem.MenuItem.Name}\nCategory - {orderItem.MenuItem.CategoryFood}\nPrice - {orderItem.MenuItem.Price}\nCount - {orderItem.Count}");
                                }
                            }
                        }
                        catch (ArgumentNull ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        catch (ConditionİsNotMetException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "6":

                        Console.WriteLine("Enter  Date :");
                        DateTime Date;
                        string dateStr = Console.ReadLine();
                        bool checkDate = DateTime.TryParse(dateStr, out Date);
                        while (!checkDate)
                        {
                            Console.WriteLine("Enter Date orrectly ! Example - (2022.04.11)");
                            dateStr = Console.ReadLine();
                            checkDate = DateTime.TryParse(dateStr, out Date);
                        }
                        try
                        {
                            foreach (var item in _restaurant.GetOrderByDate(Date))
                            {
                                foreach (var orderItem in item.OrderItems)
                                {
                                    Console.WriteLine($"No - {orderItem.MenuItem.No}\nName - {orderItem.MenuItem.Name}\nCategory - {orderItem.MenuItem.CategoryFood}\nPrice - {orderItem.MenuItem.Price}\nCount - {orderItem.Count}");
                                }

                            }
                        }
                        catch (NotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);

                        }

                        break;
                    case "7":
                        int searchByNo;
                        string searchStr = Console.ReadLine();
                        bool checkSearchNo = int.TryParse(searchStr, out searchByNo);
                        while (!checkSearchNo)
                        {
                            Console.WriteLine("Enter Correctly :");
                            searchStr = Console.ReadLine();
                            checkSearchNo = int.TryParse(searchStr, out searchByNo);
                        }
                        //foreach (Order item in _restaurant.GetOrderByNo(searchByNo))
                        //{
                        //    foreach (var orderItem in item.OrderItems)
                        //    {
                        //        Console.WriteLine($"No - {orderItem.MenuItem.No}\nName - {orderItem.MenuItem.Name}\nCategory - {orderItem.MenuItem.CategoryFood}\nPrice - {orderItem.MenuItem.Price}\nCount - {orderItem.Count}");
                        //    }

                        //}

                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while ("0" != Orders);
        }

        public static bool checkName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 4 && name.Length <= 20)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]))
                        return false;

                }
                return true;
            }
            return false;

        }



    }


}

