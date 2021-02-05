using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal MachineBalance { get; private set; }
        public decimal OldBalance { get; set; }

        public Dictionary<string, Item> Snacks = new Dictionary<string, Item>() { };

        string logPath = "..\\..\\..\\..\\VendingLog.txt";

        public VendingMachine()
        {
            this.MachineBalance = 0;
        }

        public void AddMoney(decimal amount)
        {
            OldBalance = MachineBalance;
            MachineBalance += amount;
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} FEED MONEY: {OldBalance} {MachineBalance}");
            }
        }

        public void LoadStock()
        {
            string inputPath = "..\\..\\..\\..\\vendingmachine.csv";
            using (StreamReader reader = new StreamReader(inputPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lineArray = line.Split("|");
                    Item item = new Item(lineArray[0], lineArray[1], Convert.ToDecimal(lineArray[2]), lineArray[3]);
                    Snacks.Add(lineArray[0], item);
                }

            }

        }

        public void PrintSnacks()
        {
            Console.WriteLine("Available Items");
            foreach (KeyValuePair<string, Item> item in Snacks)
            {
                Console.WriteLine($"{item.Value.Code}| {item.Value.Name} | ${item.Value.Cost} | {item.Value.Quantity} in stock");
            }
        }

        public void Vend(string code) //TODO
        {
            if (Snacks.ContainsKey(code))
            {
                if (Snacks[code].Quantity > 0)
                {
                    if (Snacks[code].Cost <= MachineBalance)
                    {
                        Snacks[code].Quantity -= 1;
                        OldBalance = MachineBalance;
                        MachineBalance -= Snacks[code].Cost;
                        Console.WriteLine($"You've purchased {Snacks[code].Name} for ${Snacks[code].Cost}. You have ${MachineBalance} remaining");
                        Console.WriteLine(GetMessage(Snacks[code].Type));
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"{DateTime.Now} {Snacks[code].Name} {Snacks[code].Code}: {OldBalance} {MachineBalance}");
                        }
                    }
                    else Console.WriteLine("Insufficient Funds");
                }
                else Console.WriteLine("Out of stock");
            }
            else
            {
                Console.WriteLine("Please enter a valid code");
            }
        }
        public string GetMessage(string type)
        {
            if (type == "Chip")
            {
                return ("Crunch Crunch, Yum!");
            }
            else if (type == "Candy")
            {
                return ("Munch Munch, Yum!");
            }
            else if (type == "Drink")
            {
                return ("Glug Glug, Yum!");
            }
            else if (type == "Gum")
            {
                return ("Chew Chew, Yum!");
            }
            return null;
        }

    }
}