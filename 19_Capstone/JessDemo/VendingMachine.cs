using MenuFramework;
using System;
using System.Collections.Generic;
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
        }
    }
}
