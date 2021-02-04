using MenuFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VendingMachineSoftware
{
    class VendingMachine
    {
        public decimal MachineBalance { get; private set; }
        public decimal OldBalance { get;  set; }

        public VendingMachine()
        {
            this.MachineBalance = 0;
        }

        public void AddMoney(decimal amount)
        {
            OldBalance = MachineBalance;
            MachineBalance += amount;
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.WriteLine($"{DateTime.Now} FEED MONEY: {OldBalance} {MachineBalance}");
            //}
        }
        public void FinishTransaction(decimal MachineBalance)
        {
            Console.WriteLine($"Your unused balance is {MachineBalance}");
            OldBalance = MachineBalance;
            int quarters = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.25M));
            MachineBalance -= quarters * 0.25M;
            int dimes = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.10M));
            MachineBalance -= dimes * 0.10M;
            int nickels = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.05M));
            MachineBalance -= nickels * 0.05M;
            Console.WriteLine($"Your change is {quarters} quarter(s), {dimes} dime(s), and {nickels} nickel(s).");
            Console.WriteLine($"Remaining Balance is {MachineBalance}");
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.WriteLine($"{DateTime.Now} GIVE CHANGE: {OldBalance} {MachineBalance}");
            //}
        }
    }
}
