using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,2,3,4};
            foreach (var item in AddTo(out arr,6))
            {
                Console.WriteLine(item);
            }
           
        }
        static int[] AddTo( out int [] arr,int num)
        {
            
            arr = new int[] { 1, 2, 3, 4,num };


            return arr;
        }
    }
}
