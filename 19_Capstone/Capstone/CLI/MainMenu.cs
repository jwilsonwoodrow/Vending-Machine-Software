using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    class Menu : ConsoleMenu
    {
        VendingMachine machine = new VendingMachine();
        public Menu()
        {
            machine.LoadStock();
            AddOption("Begin", MainMenu); //TODO help
        }
        public MenuOptionResult MainMenu()
        {
            ClearOptions();
            AddOption("Display Items", DisplayItems);
            AddOption("Purchase", BeginPurchase);
            AddOption("Exit", Exit);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        protected override void OnBeforeShow()
        {
            Console.WriteLine("Welcome to the Vending Machine");
            Console.WriteLine($"Your current balance is: ${machine.MachineBalance}");
            Console.WriteLine("");
        }

        #region MainMenu Functions

        public MenuOptionResult DisplayItems()
        {
            machine.PrintSnacks();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        public MenuOptionResult BeginPurchase()
        {
            ClearOptions();
            
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);
            AddOption("Back", GoToMainMenu);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        #endregion

        #region PurchaseMenu Functions

        public MenuOptionResult FeedMoney()
        {
            ClearOptions();
            Console.WriteLine("Select your bills");  //TODO help
            AddOption("$1.00", AddOne);
            AddOption("$2.00", AddTwo);
            AddOption("$5.00", AddFive);
            AddOption("$10.00", AddTen);
            AddOption("Back", BeginPurchase);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        public MenuOptionResult SelectProduct()
        {
            machine.PrintSnacks();
            string inputCode = GetString("Please enter desired item code: ");
            machine.Vend(inputCode);
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        public MenuOptionResult FinishTransaction()
        {
            machine.GiveChange();
            return GoToMainMenu();
        }
        public MenuOptionResult GoToMainMenu()
        {
            return MainMenu();
        }

        #endregion

        #region MoneyFunctions
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
            machine.AddMoney(10.00M);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        #endregion
        

    }
}
