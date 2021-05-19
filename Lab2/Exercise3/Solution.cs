using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class Solution
    {
        int first, second;
        public int solution()
        {
            Console.WriteLine("Please enter the first number: ");
            first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the second number: ");
            second = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            for (int i = first; i < second; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    if(j * j == i)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
