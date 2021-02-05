using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineSoftware
{
    class Transaction
    {
        public string FinishTransaction(decimal MachineBalance)
        {
            Console.WriteLine($"Your unused balance is {MachineBalance}");
            int quarters = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.25M));
            MachineBalance -= quarters * 0.25M;
            int dimes = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.10M));
            MachineBalance -= dimes * 0.10M;
            int nickels = (int)Math.Floor(Decimal.Divide(MachineBalance, 0.05M));
            MachineBalance -= nickels * 0.05M;
            return ($"Your change is {quarters} quarters, {dimes} dimes, and {nickels} nickels.");
        }
    }
}
