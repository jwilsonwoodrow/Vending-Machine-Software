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
            this.Configure(config => {      
                config.ItemForegroundColor = ConsoleColor.Green;
                config.SelectedItemForegroundColor = ConsoleColor.White;
            });
        }
        protected override void OnBeforeShow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Purchase Menu");
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
            Console.ReadKey();
            return MenuOptionResult.WaitThenCloseAfterSelection; 
        }

        #endregion

    }
}
