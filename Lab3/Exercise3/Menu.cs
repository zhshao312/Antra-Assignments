//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Exercise3
//{
//    enum AccoutingOption
//    {
//        AddExpense = 1,
//        ShowExpense,
//        SearchCost,
//        ModifiedTab,
//        DeleteData,
//        SortData,
//        NormalizeDes,
//        Exit
//    }
//    class Menu
//    {
//        public int Print()
//        {
//            string[] names = Enum.GetNames(typeof(AccoutingOption));
//            int[] values = (int[])Enum.GetValues(typeof(AccoutingOption));
//            int length = names.Length;
//            for (int i = 0; i < length; i++)
//            {
//                Console.WriteLine($"Press {values[i]} for {names[i]}");
//            }
//            Console.Write("Enter your choice => ");
//            return Convert.ToInt32(Console.ReadLine());
//        }
//    }
//}
