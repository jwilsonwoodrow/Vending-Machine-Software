using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{   [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void Machine_Constructor_Test()
        {
            // arrange
            decimal balance = 0.00M;

            //act
            VendingMachine machine = new VendingMachine();

            // assert
            Assert.AreEqual(balance, machine.MachineBalance);

        }

        [TestMethod]
        public void AddMoney_Test()
        {
            // arrange
            VendingMachine machine = new VendingMachine();
            decimal testMoney = 5.00M;

            //act 
            machine.AddMoney(testMoney);
            // Assert
            Assert.AreEqual(testMoney, machine.MachineBalance);
            Assert.AreEqual(0, machine.OldBalance);

            decimal addMore = 10.00M;
            machine.AddMoney(addMore);

            decimal expectedMachineBalnce = testMoney + addMore;


            Assert.AreEqual(expectedMachineBalnce, machine.MachineBalance);
            Assert.AreEqual(testMoney, machine.OldBalance);


        }

        //[TestMethod]
        //public void LoadStock_Test()
        //{
        //    //arrange 
        //    VendingMachine machine = new VendingMachine();
        //    Item item = new Item("E4", "Doritos", 1.75M, "Chip");
        //    Item item1 = new Item("A1", "Cola", 1.25M, "Drink");

        //    Dictionary< string, Item> testDictionary = new Dictionary<string, Item>();
        //    testDictionary.Add("E4", item);
        //    testDictionary.Add("A1", item1);


        //    //act 

        //    //assert 


        //}

        [DataTestMethod]
        [DataRow("Chip", "Crunch Crunch, Yum!")]
        [DataRow("Candy", "Munch Munch, Yum!")]
        [DataRow("Drink", "Glug Glug, Yum!")]
        [DataRow("Gum", "Chew Chew, Yum!")]
        [DataRow("", null)]
        [DataRow(null, null)]


        public void GetMessage_Test(string type, string expectedMessage)
        {
            // arrange 

            //act 

            VendingMachine machine = new VendingMachine();

            //assert 
            Assert.AreEqual(expectedMessage, machine.GetMessage(type));


        }

        [TestMethod]
        public void Vend_Quantity_Test()  //TODO help
        {
            //arrange 
            VendingMachine machine = new VendingMachine();
            machine.AddMoney(5.00M);
            Item item1 = new Item("A1", "Cola", 1.75M, "Drink");
            Item item2 = new Item("B2", "Sour Gummies", 2.00M, "Candy");
            Item item3 = new Item("C5", "BBQ Chips", 1.00M, "Chips");
            Item item4 = new Item("D4", "TripleMint", 0.75M, "Gum");

            Dictionary<string, Item> SnacksTest = new Dictionary<string, Item>
            {
                { item1.Code, item1 },
                { item2.Code, item2 },
                { item3.Code, item3 },
                { item4.Code, item4 }
            };


            // act 
            machine.Vend("A1");
            int actualCount = SnacksTest[item1.Code].Quantity;

            // assert
            Assert.AreEqual(4, actualCount);




        }


    }
}
