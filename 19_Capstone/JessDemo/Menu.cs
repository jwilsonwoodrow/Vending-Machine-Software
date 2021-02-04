using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineSoftware
{
    class Menu : ConsoleMenu
    {
        public Menu()
        {
            this.Configure(cfg =>
            {
                cfg.Title = "Welcome to the vending machine";
            });
            AddOption("Insert Bills", FeedMoney);
            AddOption("Purchase", BeginPurchase);
            AddOption("Exit", Exit);
        }
        protected override void OnAfterShow()
        {
            Console.WriteLine("");
            Console.WriteLine($"Current balance is: ${VendingMachine.MachineBalance}");
        }

        public MenuOptionResult FeedMoney()
        {
            this.ClearOptions();
            AddOption("$1.00", AddOne);
            AddOption("$2.00", AddTwo);
            AddOption("$5.00", AddFive);
            AddOption("$10.00", AddTen);
            AddOption("Back", MainMenu);

            //string input = GetString("Select bill to deposit. 1, 2, 5, and 10 bills are accepted.");
            //while (input != "q")
            //{
            //    if (Convert.ToInt32(input) == 1 || Convert.ToInt32(input) == 2 || Convert.ToInt32(input) == 5 || Convert.ToInt32(input) == 10)
            //    {
            //        balance += Convert.ToInt32(input);
            //        Console.WriteLine($"Current Balance: {balance}");
            //        input = GetString("Select another bill, or 'q' to exit.");
            //    }
            //    else input = GetString("Machine accepts 1, 2, 5, and 10 dollar bills. Please enter a valid bill or type 'q' to exit.");
            //}
            
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        public MenuOptionResult BeginPurchase()
        {
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        #region AddMoneys
        public MenuOptionResult AddOne()
        {
            AddMoney(1);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddTwo()
        {
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddFive()
        {
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddTen()
        {
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult MainMenu()
        {
            return MenuOptionResult.CloseMenuAfterSelection;
        }
        #endregion
    }
}
