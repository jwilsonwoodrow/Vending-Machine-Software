using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ItemTests
    {
            /// [TestMethod]
        //public void Constructor_TwoParameter_NameCostTest()
        //{
        //    // arrange
        //    string name = "Doritos";
        //    decimal cost = 1.75M;
            
        //    // act 
        //    Item item = new Item(name, cost);

        //    // assert
        //    Assert.AreEqual(name, item.Name);
        //    Assert.AreEqual(cost, item.Cost);
        //    Assert.AreEqual(5, item.Count);


        //}

        [TestMethod]
        public void Constructor_FourParameter_Test()
        {
            // arrange
            string code = "D1";
            string name = "Doritos";
            decimal cost = 1.75M;
            string type = "Chip";

            // act 
            Item item = new Item(code, name, cost, type);

            // assert
            Assert.AreEqual(code, item.Code);
            Assert.AreEqual(name, item.Name);
            Assert.AreEqual(cost, item.Cost);
            Assert.AreEqual(5, item.Count);
            Assert.AreEqual(type, item.Type);


        }
    }
}
