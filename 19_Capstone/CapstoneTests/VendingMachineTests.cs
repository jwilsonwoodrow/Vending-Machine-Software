using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void Machine_Constructor_Test()
        {
            // arrange
            decimal balance = 0.00M;

            //act
            VendingMachine constructorMachine = new VendingMachine();

            // assert
            Assert.AreEqual(balance, constructorMachine.MachineBalance);

        }

        [TestMethod]
        public void AddMoney_Test()
        {
            // arrange
            VendingMachine moneyMachine = new VendingMachine();
            decimal testMoney = 5.00M;

            //act 
            moneyMachine.AddMoney(testMoney);
            // Assert
            Assert.AreEqual(testMoney, moneyMachine.MachineBalance);
            Assert.AreEqual(0, moneyMachine.OldBalance);

            decimal addMore = 10.00M;
            moneyMachine.AddMoney(addMore);

            decimal expectedMachineBalnce = testMoney + addMore;


            Assert.AreEqual(expectedMachineBalnce, moneyMachine.MachineBalance);
            Assert.AreEqual(testMoney, moneyMachine.OldBalance);


        }

        [TestMethod]
        public void LoadStock_Test()
        {
            //arrange 
            int expectedQuantity = 5;

            VendingMachine machineStock = new VendingMachine();

            //act 
            machineStock.LoadStock();
            
            //assert 
            Assert.AreEqual(expectedQuantity, machineStock.Snacks["A1"].Quantity);
            Assert.AreEqual(expectedQuantity, machineStock.Snacks["C4"].Quantity);
            Assert.AreEqual(expectedQuantity, machineStock.Snacks["D2"].Quantity);
            Assert.AreEqual(expectedQuantity, machineStock.Snacks["B3"].Quantity);


        }

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

            VendingMachine stringMachine = new VendingMachine();

            //assert 
            Assert.AreEqual(expectedMessage, stringMachine.GetMessage(type));


        }

        [TestMethod]
        public void Vend_Quantity_Test() 
        {
            //arrange 
            VendingMachine machine = new VendingMachine();
            machine.AddMoney(5.00M);
            Item item1 = new Item("A1", "Cola", 1.75M, "Drink");
            Item item2 = new Item("B2", "Sour Gummies", 2.00M, "Candy");
            Item item3 = new Item("C5", "BBQ Chips", 1.00M, "Chips");
            Item item4 = new Item("D4", "TripleMint", 0.75M, "Gum");

            machine.Snacks.Add(item1.Code, item1);
            machine.Snacks.Add(item2.Code, item2);
            machine.Snacks.Add(item3.Code, item3);
            machine.Snacks.Add(item4.Code, item4);

            // act 
            machine.Vend("A1");
            int actualCount = machine.Snacks[item1.Code].Quantity;
            decimal actualOldBalance = machine.OldBalance;
            decimal actualMachineBalance = machine.MachineBalance;
            // assert
            Assert.AreEqual(4, actualCount);
            Assert.AreEqual(5.00M, actualOldBalance);
            Assert.AreEqual(3.25M, actualMachineBalance);
            

        }

        [TestMethod]

        public void GiveChange_Test()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.AddMoney(20.00M);
            testMachine.LoadStock();

            testMachine.Vend("A1");
            testMachine.Vend("B2");
            testMachine.Vend("C1");
            testMachine.Vend("D4");

            decimal actualBalance = testMachine.MachineBalance;
            testMachine.GiveChange();
            decimal machineBalanceAfterChange = testMachine.MachineBalance;

            
            Assert.AreEqual(13.45M, actualBalance);
            Assert.AreEqual(0.00M, machineBalanceAfterChange);


        }


    }
}
