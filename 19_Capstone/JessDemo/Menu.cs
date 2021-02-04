using MenuFramework;
using System;

namespace VendingMachineSoftware
{
    class Menu : ConsoleMenu
    {
        VendingMachine machine = new VendingMachine();
        public Menu()
        {
            this.Configure(cfg =>
            {
                cfg.Title = "Welcome to the Vending Machine";
            });
            AddOption("Begin", MainMenu);
        }
        public MenuOptionResult MainMenu()
        {
            ClearOptions();
            AddOption("Display Items", DisplayItems);
            AddOption("Purchase", BeginPurchase);
            AddOption("Exit", Exit);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        protected override void OnAfterShow()
        {
            Console.WriteLine("");
            Console.WriteLine($"Current balance is: ${machine.MachineBalance}");
        }
        #region Menu 1 Functions

        public MenuOptionResult DisplayItems()
        {

            //foreach (Item item in ItemDictionary)
            //{
            //    Console.WriteLine($"<{item.Code}> {item.Name}: {item.Cost}");
            //}
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        public MenuOptionResult BeginPurchase()
        {
            ClearOptions();
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", VendEnd);
            AddOption("Back", GoToMainMenu);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        #endregion
        public MenuOptionResult FeedMoney()
        {
            this.Configure(cfg =>
            {
                cfg.Title = "Welcome to the Vending Machine";
            });
            ClearOptions();
            AddOption("$1.00", AddOne);
            AddOption("$2.00", AddTwo);
            AddOption("$5.00", AddFive);
            AddOption("$10.00", AddTen);
            AddOption("Back", GoToPurchaseMenu);

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

        public MenuOptionResult SelectProduct()
        {
            string inputCode = GetString("Please enter desired item code: ");
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        #region AddMoneys
        public MenuOptionResult AddOne()
        {
            machine.AddMoney(1.00M);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddTwo()
        {
            machine.AddMoney(2.00M);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddFive()
        {
            machine.AddMoney(5.00M);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        public MenuOptionResult AddTen()
        {
            machine.AddMoney(10.05M);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        #endregion

        public MenuOptionResult GoToPurchaseMenu()
        {
            return BeginPurchase();
        }

        public MenuOptionResult GoToMainMenu()
        {
            return MainMenu();
        }

        public MenuOptionResult VendEnd()
        {
            machine.FinishTransaction(machine.MachineBalance);
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
