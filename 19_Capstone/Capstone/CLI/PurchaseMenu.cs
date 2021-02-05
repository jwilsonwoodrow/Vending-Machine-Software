using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    class PurchaseMenu : ConsoleMenu
    {
        VendingMachine machine;
        public PurchaseMenu(VendingMachine machine)
        {
            this.machine = machine;
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);
            AddOption("Back", Close);
        }
        protected override void OnBeforeShow()
        {
            Console.WriteLine("Welcome to the Vending Machine");
            Console.WriteLine($"Your current balance is: ${machine.MachineBalance}");
            Console.WriteLine("");
        }


        #region PurchaseMenu Functions

        public MenuOptionResult FeedMoney()
        {
            FeedMoneyMenu moneyMenu = new FeedMoneyMenu(machine);
            moneyMenu.Show();
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
            return MenuOptionResult.WaitThenCloseAfterSelection; 
        }

        #endregion

    }
}
