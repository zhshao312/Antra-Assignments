using System;

namespace Exercise2
{
    class Program
    {
      
        static void Main(string[] args)
        {         
            MostValueArray mostValueArray = new MostValueArray();
            int[] arr = mostValueArray.getData();
            Console.WriteLine($"The value that occurs most often in array is {mostValueArray.Solution(arr)}");

        }
    }
}
