using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 50;
            int[] array = new int[arraySize];
            
            array = fillArray(array, arraySize);
            array = replaceArrayValue(array, arraySize);
            printArray(array);

            Array.Sort(array);

            displayMissingValue(array);

            printArray(array);
        }

        //Test Data
        public static Dictionary<int[],int[]> IArrays()
        {
            int[] array1 = new int[] { 1,2,3,4,5};
            int[] array2 = new int[] { 1, 2, 3, 0, 5 };
            Dictionary<int[], int[]> returnDictionary = new Dictionary<int[], int[]>();
            returnDictionary.Add(array1, array2);
            return returnDictionary;
        }

        public static void displayMissingValue(int[] array)
        {
            int difference = 0;
            for (int i = array.Length; i > 0; i--)
                difference += i;

            int sum = 0;
            for (int j = 0; j < array.Length; j++)
                sum += array[j];

           difference -= sum;
           Console.WriteLine($"Missing number: {difference}");
        }

        public static int[] fillArray(int[] array, int total)
        {
            for(int i = 0; i < total; i++)
                array[i] = i + 1;

            return shuffleArray(array);
        }

        public static int[] shuffleArray(int[] array)
        {
            Random random = new Random();
            array = array.OrderBy(x => random.Next()).ToArray();
            return array;
        }

        public static void printArray(int[] array)
        {
            foreach (int number in array)
                Console.Write(number + " ");
            Console.WriteLine();
        }

        public static int[] replaceArrayValue(int[] array, int total)
        {
            array[chooseRandomIndex(total)] = 0;
            return array;
        }

        public static int chooseRandomIndex(int total)
        {
            Random r = new Random();
            return r.Next(0, total - 1);
        }
    }
}
