//I was asked this question in an interview so I decided to write the solution I provided.
//Question: You have an array with numbers 1-50, not in order and one value is replaced with 0.
//How do you find which value is "missing" (replaced with 0)?

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
            
            //Populate array from numbers 1 to given arraySize
            array = fillArray(array, arraySize);

            //Replace a random value with the number 0
            array = replaceArrayValue(array, arraySize);

            Console.WriteLine($"Missing Value: {calculateMissingValue(array)}");


            //Print array before and after sorting to compare results with actual values
            printArray(array);
            Array.Sort(array);
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
        
        //Solution 1
        //Find the missing value in the array by calculating the difference in actual vs expected array sums
        public static int calculateMissingValue(int[] array)
        {
            int expectedArraySum = 0;
            for (int i = array.Length; i > 0; i--)
                expectedArraySum += i;

            int actualArraySum = 0;
            for (int j = 0; j < array.Length; j++)
                actualArraySum += array[j];

            return expectedArraySum - actualArraySum;
        }

        //Populeate the values in the array start at 1 and ending at the given array size
        public static int[] fillArray(int[] array, int arraySize)
        {
            for(int i = 0; i < arraySize; i++)
                array[i] = i + 1;

            return shuffleArray(array);
        }

        //Shuffle the order of the values in the array
        public static int[] shuffleArray(int[] array)
        {
            Random random = new Random();
            array = array.OrderBy(x => random.Next()).ToArray();
            return array;
        }

        //Print out the values in the array in a single line
        public static void printArray(int[] array)
        {
            foreach (int number in array)
                Console.Write(number + " ");
            Console.WriteLine();
        }

        //Replace a value in the array with a 0
        public static int[] replaceArrayValue(int[] array, int arraySize)
        {
            array[chooseRandomIndex(arraySize)] = 0;
            return array;
        }

        //Random number generator used to select an index value in the array
        public static int chooseRandomIndex(int arraySize)
        {
            Random random = new Random();
            return random.Next(0, arraySize - 1);
        }
    }
}
