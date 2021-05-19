using System;

namespace Exercise4
{
    class ArmstrongNumber
    {
        int first, second;
        int sum, temp, num, r;

        public void FindArmstrong()
        {
                Console.WriteLine("Please Enter the first number: ");
                first = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter the second number: ");
            second = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The armstrong number between your inputs are: ");
            if (first < second) {
                for (num = first; num <= second; num++) 
                {
                    temp = num;
                    sum = 0;

                    while (temp != 0) {
                        r = temp % 10;
                        temp = temp / 10;
                        sum = sum + (r * r * r);
                    }
                    if (sum == num)
                    {
                        Console.WriteLine("{0} ", num);
                    }
                }
                Console.Write("\n");
            }
            else
            {
                for (num = second; num <= first; num++)
                {
                    temp = num;
                    sum = 0;

                    while (temp != 0)
                    {
                        r = temp % 10;
                        temp = temp / 10;
                        sum = sum + (r * r * r);
                    }
                    if (sum == num)
                    {
                        Console.WriteLine("{0}", num);
                    }
                }
                Console.Write("\n");
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArmstrongNumber an = new ArmstrongNumber();
            an.FindArmstrong();
            Console.ReadKey();
        }
    }
}
