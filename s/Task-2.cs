using System;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String Sentence = "Code Academy";
            Array(ref Sentence);
            Console.WriteLine(Sentence);
        }
        static void Array(ref string Sentence)
        {
            Sentence = "/CodeAcademy";
        }
    }
}
