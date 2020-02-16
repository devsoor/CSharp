using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] numArray = new int[5] {1,2,3,4,5};
            GetAverage(numArray);
            int res = GreaterThanY(numArray, 2);
            Console.WriteLine("GreaterThanY: " + res);
            SquareArrayValues(numArray);
            int[] shiftArr = new int[5] {1, 5, 10, 7, -2};
            ShiftValues(shiftArr);
            int[] negArr = new int[4] {1, 5, 10, -2};
            EliminateNegatives(negArr);
            int[] objArr = new int[3] {-1, -3, 2};
            object[] a = new object[3];
            a = NumToString(objArr);
            Console.WriteLine("a = " + string.Join(", ", a));
        }

        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            int avg = sum / numbers.Length;
            Console.WriteLine("GetAverage: " + avg);
        }
        public static int GreaterThanY(int[] numbers, int y)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    result++;
                }
            }
            return result;
        }

        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
                Console.WriteLine("EliminateNegatives: " + string.Join(", ", numbers));
        }

        public static void SquareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i]*numbers[i];
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void ShiftValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)
            {
                numbers[i] = numbers[i+1];
            }
            numbers[numbers.Length-1] = 0;
            Console.WriteLine(string.Join(", ", numbers));
        }

        public static object[] NumToString(int[] numbers)
        {
            object[] arr = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    arr[i] = "Dojo";
                } else {
                    arr[i] = numbers[i];
                }
            }
            return arr;

        }
    }
}
