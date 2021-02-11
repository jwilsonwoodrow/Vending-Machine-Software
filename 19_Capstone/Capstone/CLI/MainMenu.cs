using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    class MainMenu : ConsoleMenu
    {
        VendingMachine machine = new VendingMachine();
        public MainMenu()
        {
            machine.LoadStock();
            AddOption("Display Items", DisplayItems);
            AddOption("Purchase", BeginPurchase);
            AddOption("Exit", Exit);
             this.Configure(config => {
                  config.SelectedItemForegroundColor = ConsoleColor.White;
                  config.ItemForegroundColor = ConsoleColor.DarkCyan;
          
              });
        }

        protected override void OnBeforeShow()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to the Vendo-Matic 8000");
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
            PurchaseMenu menu = new PurchaseMenu(machine);  
            menu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        #endregion

    }
}
