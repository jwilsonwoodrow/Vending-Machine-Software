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

        public Item(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public Item(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }
        


        public void GetMessage()
        {
            string path = "vendingmachine.csv";
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] lineArray = line.Split("|");
                    this.Type = lineArray[3];
                    if (this.Type == "Chip")
                        {
                        Console.WriteLine("Crunch Crunch, Yum!");
                        }
                    else if (this.Type == "Candy")
                    {
                        Console.WriteLine("Munch Munch, Yum!");
                    }
                    else if (this.Type == "Drink")
                    {
                        Console.WriteLine("Glug Glug, Yum!");
                    }
                    else if (this.Type == "Gum")
                    {
                        Console.WriteLine("Chew Chew, Yum!");
                    }
                }

            }




        }







    }
}
