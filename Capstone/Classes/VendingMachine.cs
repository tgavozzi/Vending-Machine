using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private decimal currentBalance;
        public Dictionary<string, List<VendingMachineItem>> inventory;
        // private TransactionFileLog transactionLogger;

        public decimal CurrentBalance
        {
            get { return currentBalance; }
        }

        public string[] Slots
        {
            get { return this.inventory.Keys.ToArray(); }
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance += dollars;
        }

        public VendingMachine()
        {
            InventoryFileDAL fileReader = new InventoryFileDAL();
            this.inventory = fileReader.GetInventory();
        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> inventory)
        {
            this.inventory = inventory;
        }

        public Change ReturnChange()
        {

            decimal changeToGive = this.currentBalance;
            this.currentBalance = 0;
            return new Change(changeToGive);

        }

        public VendingMachineItem GetItemAtSLot(string slotId)
        {
            List<VendingMachineItem> vending = inventory[slotId];
            return vending[0];

        }

        public int GetQuantityRemaining(string slotId)
        {
            if (inventory.ContainsKey(slotId))
            {
                return inventory[slotId].Count();
            }
            return inventory[slotId].Count();
        }

        public VendingMachineItem Purchase(string slotId)
            {
                List<VendingMachineItem> purchaseItem = inventory[slotId];

                try
                {
                    if (inventory[slotId].Count() > 1)
                    {
                        if (inventory.ContainsKey(slotId) && this.currentBalance >= purchaseItem[0].Price)
                        {
                            this.currentBalance -= purchaseItem[0].Price;
                            inventory[slotId].Remove(purchaseItem[0]);
                            return purchaseItem[0];
                        }

                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
    }        //if (!inventory.ContainsKey(slotId))
         //{
         //    return null;
         //}
         //else if (inventory.ContainsKey(slotId) && inventory[slotId].Count() < 0)
         //{
         //    return null;
         //}
         //else if (inventory.ContainsKey(slotId) && this.currentBalance <= purchaseItem[0].Price)
         //{
         //    return null;
         //}
