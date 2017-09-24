using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class OutOfStockException : VendingMachineException
    {
        public OutOfStockException(string message)
                : base(message)
        {

        }
    }
}
