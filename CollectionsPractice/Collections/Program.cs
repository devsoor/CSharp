using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr09 = {0,1,2,3,4,5,6,7,8,9};
            string[] arrNames = {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string name in arrNames)
            {
                Console.WriteLine($"{name}");
            }
            bool[] arrBool = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                if (i%2 == 0)
                {
                    arrBool[i] = true;
                } else {
                    arrBool[i]  = false;
                }
            }
            Console.WriteLine($"arrBool: {arrBool}");

            List<string> flavors = new List<string>{};
            flavors.Add("Strawberry");
            flavors.Add("Berry");
            flavors.Add("Coconut");
            flavors.Add("Vanilla");
            flavors.Add("Mint");
            flavors.Add("Pineapple");

            foreach (string f in flavors)
            {
                Console.WriteLine($"{f}");
            }

            Console.WriteLine($"Length of Flavors list is {flavors.Count}");
            Console.WriteLine($"3rd flavor in the list is: {flavors[2]}");
            flavors.RemoveAt(2);
            foreach (string f in flavors)
            {
                Console.WriteLine($"{f}");
            }           
            Console.WriteLine($"Length of Flavors list is {flavors.Count}"); 

            Dictionary<string, string> nameFlavor = new Dictionary<string, string>();
            Random rand = new Random();
            foreach (string name in arrNames)
            {
                nameFlavor.Add(name,flavors[rand.Next(flavors.Count)]);
            }

            foreach (var entry in nameFlavor)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }
    }
}
