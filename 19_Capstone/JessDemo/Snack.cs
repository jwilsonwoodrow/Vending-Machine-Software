using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineSoftware
{
    public class Item
    {
        public string Name { get; }
        public decimal Cost { get; }
        public string Code { get; }

        public string Type { get; }

        public int Count = 5;
    }
}
