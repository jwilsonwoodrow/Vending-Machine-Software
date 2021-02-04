using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Machine
    {
        public decimal MachineBalance { get; private set; }
        public decimal OldBalance { get; set; }

        public Dictionary<string, Item> Snacks = new Dictionary<string, Item>() { };


        public Machine()
        {
            this.MachineBalance = 0;
        }

        public void AddMoney(decimal amount)
        {
            OldBalance = MachineBalance;
            MachineBalance += amount;
        }


        public void LoadStock()
        {   
            string path = "vendingmachine.csv";
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] lineArray = line.Split("|");
                    Item item = new Item(lineArray[1], 5);
                    Snacks.Add(lineArray[0], item);

                }

            }

        }







    }
}
