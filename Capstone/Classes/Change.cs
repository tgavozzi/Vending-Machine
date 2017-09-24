using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Change
    {
        private int dimes;
        private int nickels;
        private int quarters;
        //private double totalChange;


        public int Dimes
        {
            get { return this.dimes; }
        }

        public int Nickels
        {
            get { return this.nickels; }
        }

        public int Quarters
        {
            get { return this.quarters; }
        }

        public double TotalChange
        {
            get { return (dimes * 10 + nickels * 5 + quarters * 25); }
        }

        public Change(decimal amountInDollars)
        {

            while (amountInDollars >= .25M)
            {
                this.quarters += 1;
                amountInDollars -= .25M;
            }
            while (amountInDollars >= .10M)
            {
                this.dimes += 1;
                amountInDollars -= .10M;
            }
            while (amountInDollars >= .05M)
            {
                this.nickels += 1;
                amountInDollars -= .05M;
            }

        }

        public Change(int amountInCents)
        {
            while (amountInCents >= 25)
            {
                this.quarters += 1;
                amountInCents -= 25;
            }
            while (amountInCents >= 10)
            {
                this.dimes += 1;
                amountInCents -= 10;
            }
            while (amountInCents >= 5)
            {
                this.nickels += 1;
                amountInCents -= 5;
            }
        }

    }
}


