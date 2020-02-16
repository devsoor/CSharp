using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rarr = new int[10];
            rarr = RandomArray();
            Console.WriteLine("Random Array - rarr: " + string.Join(", ", rarr));
            int maxNum = rarr[0];
            int minNum = rarr[0];
            int sum = 0;
            foreach (int x in rarr) {
                if (x > maxNum) {
                    maxNum = x;
                } else if (x < minNum) {
                    minNum = x;
                }
                sum += x;
            }
            Console.WriteLine("Min = " + minNum + " Max = " + maxNum + " Sum = " + sum);

            string tossResult = TossCoin();
            Console.WriteLine("Tossed = " + tossResult);

            Double r = TossMultipleCoins(5);
            Console.WriteLine("Ratio of heads to tails = " + r);

            List<string> namesList = new List<string>{"Todd", "Tiffany", "Charlie", "Geneva", " Ben", "Sydney"};
            List<string> newNames = Names(namesList);
            Console.WriteLine("Shuffled list = " + string.Join(", ", newNames));
        }

        public static int[] RandomArray()
        {
            int[] randArray = new int[10];
            Random rand = new Random();
            for (int i = 0; i < randArray.Length; i++)
            {
                randArray[i] = rand.Next(5,26);
            }
            return randArray;
        }

        public static string TossCoin()
        {
            string str = "Tossing a Coin";
            Console.WriteLine(str);
            Random rand = new Random();
            int toss = rand.Next(0,2);
            if (toss == 0) {
                return "Heads";
            } else {
                return "Tails";
            }
        }
        public static Double TossMultipleCoins(int num)
        {
            int headCount = 0;
            int tailCount = 0;
            for (int i = 0; i < num; i++)
            {
                string tossResult = TossCoin();
                if (tossResult == "Heads")
                {
                    headCount++;
                } else {
                    tailCount++;
                }
            }
            Double ratio = (Double)headCount/tailCount;
            return ratio;
        }

        public static List<string> Names(List<string> names)
        {
            Console.WriteLine(string.Join(", ", names));
            Random rand = new Random();
            int totalItems = names.Count;
            while (totalItems > 1)
            {
                // get a random index and replace it with last element
                totalItems--;
                int randIndex = rand.Next(totalItems);
                string value = names[randIndex];
                names[randIndex] = names[totalItems];
                names[totalItems] = value;
            }
            Console.WriteLine("Names(): Shuffled list = " + string.Join(", ", names));
            List<string> newNamesList = new List<string>{};

            foreach (string n in names)
            {
                if (n.Length > 5)
                {
                    newNamesList.Add(n);
                }
            }
            return newNamesList;
        }
    }
}
; 