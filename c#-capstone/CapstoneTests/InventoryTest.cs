using System;
using Capstone;
using Capstone.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void Sale()
        {
            InventoryClass inventory = new InventoryClass();
            Account account = new Account();
            account.Balance = 17.88m;
            inventory.Sale("B2", account);

            Assert.AreEqual(16.38m, account.Balance, "Input: B2 & account");
            Assert.AreEqual(4, inventory.ItemLocation["B2"].QuantityLeft, "Input: B2");
        }

        [TestMethod]
        public void FinishTransaction()
        {
            InventoryClass inventory = new InventoryClass();
            Account account = new Account();
            account.Balance = 1.41m;
            account.FinishTransaction();
            CollectionAssert.AreEqual(new[] { 1, 1, 1, 1, 1, }, account._changeReturn);

            Account account2 = new Account();
            CollectionAssert.AreEqual(new[] { 0, 0, 0, 0, 0, }, account2._changeReturn);

        }
        [TestMethod]
        public void RemoveFromStock()
        {
            InventoryClass inventory = new InventoryClass();
            Account account = new Account();
            account.Balance = 99m;
            inventory.Sale("A1", account);
            inventory.Sale("A1", account);
            inventory.Sale("A1", account);
            inventory.Sale("A1", account);
            inventory.Sale("A1", account);

            Assert.IsFalse(inventory.ItemLocation.ContainsKey("A1"));
            Assert.IsTrue(inventory.ItemLocation.ContainsKey("A2"));

        }
        [TestMethod]
        public void SellNonExistantKey()
        {
            Account account = new Account();
            account.Balance = 99m;
            InventoryClass inventory = new InventoryClass();
            inventory.Sale("g1", account);
            Assert.AreEqual(99, account.Balance);
        }
        [TestMethod]
        public void SoundOverride()
        {
            InventoryClass inv = new InventoryClass();
            Assert.AreEqual("Crunch, Crunch, Yum!", inv.ItemLocation["A4"].GetSound());
        }
    }
}
