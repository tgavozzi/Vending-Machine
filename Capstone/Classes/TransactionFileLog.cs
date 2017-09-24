using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class TransactionFileLog
    {
        private string fullFilePath;

        public TransactionFileLog(string filePath)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            fullFilePath = Path.Combine(currentDirectory, filePath);
        }

        public void RecordCompleteTransaction(decimal initialAmount)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {
                    sw.WriteLine(DateTime.Now + " " + "GIVE CHANGE: " + initialAmount.ToString("C") + " " + "$ 0.00");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void RecordDeposit(int dollars, decimal currentBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {
                    sw.WriteLine(DateTime.Now + " " + "FEED MONEY: " + " " + dollars.ToString("C") + " " + currentBalance.ToString("C"));
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RecordPurchase(string productName, string slotId, decimal initialBalance, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                {
                    sw.WriteLine(DateTime.Now + " " + productName + "(" + slotId + ")" + " " + initialBalance.ToString("C") + " " + finalBalance.ToString("C"));

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
