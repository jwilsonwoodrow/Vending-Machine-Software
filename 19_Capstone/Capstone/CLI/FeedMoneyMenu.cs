using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    class FeedMoneyMenu : ConsoleMenu
    {
        VendingMachine machine;
        public FeedMoneyMenu(VendingMachine machine)
        {
            this.machine = machine;
            AddOption("$1.00", AddOne);
            AddOption("$2.00", AddTwo);
            AddOption("$5.00", AddFive);
            AddOption("$10.00", AddTen);
            AddOption("Back", Close);
            this.Configure(config => {
                config.SelectedItemForegroundColor = ConsoleColor.White;
                config.ItemForegroundColor = ConsoleColor.Green;

            });
        }
        protected override void OnBeforeShow()
        {
            Console.WriteLine("Please insert your bills");
            Console.WriteLine($"Your current balance is: ${machine.MachineBalance}");
            Console.WriteLine("");
        }

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
