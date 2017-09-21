using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        public string itemName;
        public decimal priceInCents;

        public string ItemName
        {
            get { return this.itemName; }
        }

        public decimal Price
        {
            get { return this.priceInCents; }
        }

        public abstract string Consume();

        public VendingMachineItem(string itemName, decimal price)
        {
            this.itemName = itemName;
            this.priceInCents = (price * 100); //should this be * 100?
        }




    }
}
