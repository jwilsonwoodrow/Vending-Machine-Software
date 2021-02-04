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

    }
}
