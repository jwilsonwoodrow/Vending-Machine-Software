using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Item
    {
        public string Name { get; }
        public decimal Cost { get; }
        public string Code { get; }

        public string Type { get; private set; }

        public int Quantity = 5;

        public Item(string code, string name, decimal cost, string type)
        {
            Code = code;
            Name = name;
            Cost = cost;
            Type = type;
            
        }
        
        


       
    }
}
