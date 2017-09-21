using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
   public class Program
    {
        
        static void Main(string[] args)
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(100);
            test.ReturnChange();
            
        }
        
     
    }
}
