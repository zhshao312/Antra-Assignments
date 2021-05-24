using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class HouseHoldAccount
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }

        HouseHoldAccount[] income = new HouseHoldAccount[10000];
        HouseHoldAccount[] expense = new HouseHoldAccount[10000];

        public void Operations()
        {
            HouseHoldAccount houseHoldAccount = new HouseHoldAccount();

            Menu:
            Console.WriteLine($"Press 1 for Adding Expenses");
            Console.WriteLine($"Press 2 for Showing Expenses");
            Console.WriteLine($"Press 3 for Search Costs");
            Console.WriteLine($"Press 4 for Modify A Tab");
            Console.WriteLine($"Press 5 for Delete Data");
            Console.WriteLine($"Press 6 for Sort Data");
            Console.WriteLine($"Press 7 for Normalize Description");
            Console.WriteLine($"Press 8 for Exit");
            Console.Write($"Please enter your choice: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option) 
            {
                case 1:
                    houseHoldAccount.AddAccountingDetail();
                    goto Menu;

                case 2:
                    houseHoldAccount.ShowExpense();
                    goto Menu;
                
                case 3:
                    houseHoldAccount.SearchCosts();
                    goto Menu;
                
                case 8:
                    break;
            }

                
        }
        public void AddAccountingDetail()
        {
            int length = expense.Length;
            HouseHoldAccount houseHoldAccount = new HouseHoldAccount();

            AddExpense:

                for (int i = 0; i < length; i++)
                {           
                    Console.Write("Enter Accounting Id => ");
                    houseHoldAccount.Id = Convert.ToInt32(Console.ReadLine());
                Date:
                    Console.Write("Enter Date(YYYYMMDD) => ");
                    houseHoldAccount.Date = Console.ReadLine();
                    if (Convert.ToInt32(houseHoldAccount.Date.Substring(0, 4)) >= 3000 || Convert.ToInt32(houseHoldAccount.Date.Substring(0, 4)) <= 1000
                        || Convert.ToInt32(houseHoldAccount.Date.Substring(4, 2)) > 12 || Convert.ToInt32(houseHoldAccount.Date.Substring(4, 2)) < 1
                        || Convert.ToInt32(houseHoldAccount.Date.Substring(6, 2)) > 31 || Convert.ToInt32(houseHoldAccount.Date.Substring(6, 2)) < 1
                        || houseHoldAccount.Date.Length > 8 || houseHoldAccount.Date.Length < 8)
                    {
                        Console.WriteLine("Invalid Date Input");
                        goto Date;
                    }

                Description:
                    Console.Write("Enter Description => ");
                    houseHoldAccount.Description = Console.ReadLine();
                    if(houseHoldAccount.Description == "")
                    {
                        Console.WriteLine("Description must not be empty!");
                        goto Description;
                    }
                
                    Console.Write("Enter Category => ");
                    houseHoldAccount.Category = Console.ReadLine();
                
                    Console.Write("Enter Amount(positive if income, negative if expense) => ");
                    houseHoldAccount.Amount = Convert.ToDouble(Console.ReadLine());
                    if(houseHoldAccount.Amount >= 0)
                    {
                        income[i] = houseHoldAccount;
                    }
                    else
                    {
                        expense[i] = houseHoldAccount;
                    }

                Console.Write("Do you want to enter one more trade?(Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                    goto AddExpense;
                else
                {
                    break;
                }

            }
        }

        public void ShowExpense() 
        {
            Console.Write("Show all expenses between two certain dates. Please enter first date(YYYYMMDD): ");
            int firstDate = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter second date(YYYYMMDD): ");
            int secondDate = Convert.ToInt32(Console.ReadLine());
            
            int length = expense.Length;

            for (int i = 0; i < length; i++)
            {
                if (Convert.ToInt32(expense[i].Date) >= firstDate && Convert.ToInt32(expense[i].Date) <= secondDate)
                {                  
                    Console.WriteLine($"Number: {expense[i].Id} - Date: {expense[i].Date.Substring(6, 2)}/{expense[i].Date.Substring(4, 2)}/{expense[i].Date.Substring(0,4)} " +
                        $"- description: {expense[i].Description} - ({expense[i].Category}) - amount: {expense[i].Amount}");
                }
                else{
                    Console.WriteLine("No data found between the certain dates!");
                }

            }
            double sum = 0;
            for (int i = 0; i < expense.Length; i++)
            {
                sum = sum + expense[i].Amount;
            }
            Console.WriteLine($"---------------------------------------------------------------------------Total Expense: {sum}");

        }

        public void SearchCosts()
        {
            HouseHoldAccount houseHoldAccount = new HouseHoldAccount();
            int length = expense.Length;

            Console.WriteLine("Please enter the keywords in description or category you want to search: ");
            string input = Console.ReadLine();

            for (int i = 0; i < length; i++)
            {
                if(expense[i].Description == input || expense[i].Category == input)
                {
                    houseHoldAccount = expense[i];
                    Console.WriteLine($"Number: {houseHoldAccount.Id} - Date: {houseHoldAccount.Date.Substring(6, 2)}/{houseHoldAccount.Date.Substring(4, 2)}/{houseHoldAccount.Date.Substring(0, 4)} " +
                        $"- description: {houseHoldAccount.Description} - ({houseHoldAccount.Category}) - amount: {houseHoldAccount.Amount}");
                }
            }
        }
    }
}
