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

        public Dictionary<string, Item> Snacks = new Dictionary<string, Item>(StringComparer.InvariantCultureIgnoreCase) { };

        string logPath = "..\\..\\..\\..\\VendingLog.txt";

        public VendingMachine()
        {
            this.MachineBalance = 0.00M;
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
            Console.WriteLine("Available Items:");
            foreach (KeyValuePair<string, Item> item in Snacks)
            {
                if (item.Value.Quantity == 0)
                {
                    Console.WriteLine($"{item.Value.Code} | {item.Value.Name} SOLD OUT");
                }
                else Console.WriteLine($"{item.Value.Code} | {item.Value.Name} | ${item.Value.Cost} | {item.Value.Quantity} in stock");
            }
        }

        public void Vend(string code)
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
                        string typeMessage = GetMessage(Snacks[code].Type);
                        Console.WriteLine("");
                        Console.WriteLine($"You've purchased {Snacks[code].Name} for ${Snacks[code].Cost}. {typeMessage} You have ${MachineBalance} remaining");
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"{DateTime.Now} {Snacks[code].Name} {Snacks[code].Code}: {OldBalance} {MachineBalance}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Error: Insufficient Funds");
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Error: Item Out of stock");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Error: Please Enter a Valid code");

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

        public void GiveChange()
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
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} GIVE CHANGE: {OldBalance} {MachineBalance}");
            }
            Console.WriteLine("Thank you for choosing Vendo-Matic 8000");
           
        }
    }
}