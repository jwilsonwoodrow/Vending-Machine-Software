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

        public int Count = 5;

        public Item(string code, string name, decimal cost, string type)
        {
            Code = code;
            Name = name;
            Cost = cost;
            Type = type;
            
        }
        //public Item(string name, decimal cost)
        //{
        //    this.Name = name;
        //    this.Cost = cost;
        //}

        //public Item(string name, int count)
        //{
        //    this.Name = name;
        //    this.Count = count;
        //}
        


       
    }
}
