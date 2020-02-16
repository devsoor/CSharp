using System;
using System.Collections.Generic;

namespace BoxUnbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            int sum = 0;
            for (int i = 0; i < myList.Count; i++){
                if (myList[i] is int) {
                    sum += (int)myList[i];
                }
            }
            Console.WriteLine("sum = " + sum);
        }
    }
}
