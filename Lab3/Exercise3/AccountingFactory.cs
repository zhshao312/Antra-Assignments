//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Exercise3
//{
//    class AccountingFactory
//    {
//        public HouseHoldAccount GetObject(int choice)
//        {

//            HouseHoldAccount house = new HouseHoldAccount();
//            switch (choice)
//            {
//                case (int)AccoutingOption.AddExpense:
//                    return house.AddAccountingDetail();
//                case (int)AccoutingOption.ShowExpense:
//                    return house.ShowExpense();
//                default:
//                    return null;
//            }
//        }
//    }
//}
