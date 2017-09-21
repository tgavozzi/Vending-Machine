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
        private string[] slots;
        private Dictionary<string, List<VendingMachineItem>> inventory;
        private InventoryFileDAL inventorySource;
        // private TransactionFileLog transactionLogger;

        public decimal CurrentBalance
        {
            get { return currentBalance; }
        }

        public string[] Slots
        {
            get { return slots; }
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance += dollars;
        }

        public VendingMachine()
        {
            InventoryFileDAL fileReader = new InventoryFileDAL();
            fileReader.GetInventory();
        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>>inventory)
        {
            this.inventory = inventory; 
        }

        public Change ReturnChange()
        {
            decimal changeToGive = this.currentBalance;
            this.currentBalance = 0;
            return new Change(this.currentBalance);
      
        }

        public VendingMachineItem GetItemAtSLot(string slotId)
        {
            List<VendingMachineItem> vending = new List<VendingMachineItem>();
            vending = inventory[slotId];
            string name = vending[0].itemName;
            string price = vending[0].Price.ToString();
            string[] temp = new string[] { name, price };
            this.slots = temp;

            return null;

        }
        //public int GetQuantityRemaining(string slotId)
        //{
        //    return inventory.
        //}



    }
}
