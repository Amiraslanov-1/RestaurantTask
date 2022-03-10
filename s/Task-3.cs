using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Add());

        }
        static int Add(int num=35)
        {
            int i=0;
            while (i*i<num)
            {
                i++;
            }
            return i-1;

        }
    }
}
