using System;

namespace RestaurantTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodForMenu method = new MethodForMenu();
            string choice;
            do
            {
                method.ShowMenu();
              
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        method.MenuItem();
                        break;
                    case "2":
                        method.OrderItem();
                        break;
                    case "3":
                        Console.WriteLine("|----------------------- Program Ended -----------------------|");
                        break;

                    default:
                        Console.WriteLine(" Your Choice Can Be 1, 2 or 3 !");
                        break;
                }
            } while (choice != "3");
        }
    }
}
