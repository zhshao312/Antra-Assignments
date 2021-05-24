//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Exercise3
//{
//    class ManageAccouting
//    {
//        public void Run()
//        {
//            int option = (int)AccoutingOption.Exit;

//            do
//            {
//                Console.Clear();
//                Menu m = new Menu();
//                option = m.Print();
//                AccountingFactory accountingFactory = new AccountingFactory();
//                HouseHoldAccount houseHoldAccount = accountingFactory.GetObject(option);

//                Console.WriteLine("Press Enter to continue....");
//                Console.ReadLine();

//            } while (option != (int)AccoutingOption.Exit);
//        }
//    }
//}
