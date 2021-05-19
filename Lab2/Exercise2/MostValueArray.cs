using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class MostValueArray
    {
        int size = 0;
        int value = 0;
        int[] arr;
        public int Solution(int[] a)
        {
            arr = a;
            int c = 1, maxcount = 1, maxvalue = 0;
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                maxvalue = arr[i];
                for (int j = 0; j < arr.Length; j++)
                {
                    if (maxvalue == arr[j] && j != i)
                    {
                        c++;
                        if (c > maxcount)
                        {
                            maxcount = c;
                            result = arr[i];
                        }
                    }
                    else
                    {
                        c = 1;
                    }
                }
            }
            return result;
        }

        public int[] getData()
        {
        repeatSize:
            Console.WriteLine("Enter the size of the array:");
            size = Convert.ToInt32(Console.ReadLine());
            if (size < 1 || size > 1000)
            {
                goto repeatSize;
            }
            arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
            repeatValue:
                Console.WriteLine("Enter the value of the array:");
                value = Convert.ToInt32(Console.ReadLine());
                if (value < 0 || value > 10000)
                {
                    goto repeatValue;
                }
                arr[i] = value;

            }
            return arr;
        }
    }
}
