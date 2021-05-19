using System;

namespace Exercise7
{
    class ATM
    {
        int pin = 123, balance = 1000;
        int pinInput, choice, withdraw, deposit;

        public void ATMStart()
        {
            Console.WriteLine("Enter Your Pin Number:");
            pinInput = Convert.ToInt32(Console.ReadLine());
            while(pinInput != pin)
            {
                Console.WriteLine("Sorry you input pin is incorrect, please enter again: ");
                pinInput = Convert.ToInt32(Console.ReadLine());
            }
            start:
            Console.WriteLine("******************Welcome to ATM Service****************");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Cash");
            Console.WriteLine("3. Deposit Cash");
            Console.WriteLine("4. Quit");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("Enter Your Choice:");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) 
            {
                case 1:
                    Console.WriteLine("Your balance is: " + balance);
                    goto start;
                case 2:
                    Console.WriteLine("How much you want to withdraw?");
                    withdraw = Convert.ToInt32(Console.ReadLine());
                    balance = balance - withdraw;
                    goto start;
                case 3:
                    Console.WriteLine("How much you want to deposit?");
                    deposit = Convert.ToInt32(Console.ReadLine());
                    balance = balance + deposit;
                    goto start;
                case 4:
                    Console.WriteLine("Bye!");
                    break;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.ATMStart();
        }
    }
}
