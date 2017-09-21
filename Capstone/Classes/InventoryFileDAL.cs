using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class InventoryFileDAL
    {
        private const int cost = 2;
        private const int product = 1;
        private const int slotId = 0;
        Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            return inventory;
        }


        public InventoryFileDAL()
        {
            string filePath = "vendingmachine.csv";
            string currentDirectory = Directory.GetCurrentDirectory();
            string fullFilePath = Path.Combine(currentDirectory, filePath);

            using (StreamReader sr = new StreamReader(fullFilePath))
            {

                while (!sr.EndOfStream)
                {
                    string nextLine = sr.ReadLine();
                    string[] line = nextLine.Split('|');

                    string slot = line[slotId];
                    string name = line[product];
                    decimal price = decimal.Parse(line[cost]);

                    if (slot.StartsWith("A"))
                    {
                        List<VendingMachineItem> list = new List<VendingMachineItem>();

                        for (int i = 0; i < 5; i++)
                        {
                            ChipItem chip = new ChipItem(name, price);
                            list.Add(chip);
                        }
                        inventory[slot] = list;

                    }
                    if (slot.StartsWith("B"))
                    {
                        List<VendingMachineItem> list = new List<VendingMachineItem>();

                        for (int i = 0; i < 5; i++)
                        {
                            CandyItem candy = new CandyItem(name, price);
                            list.Add(candy);
                        }
                        inventory[slot] = list;

                    }
                    if (slot.StartsWith("C"))
                    {
                        List<VendingMachineItem> list = new List<VendingMachineItem>();

                        for (int i = 0; i < 5; i++)
                        {
                            BeverageItem beverage = new BeverageItem(name, price);
                            list.Add(beverage);
                        }
                        inventory[slot] = list;

                    }
                    if (slot.StartsWith("D"))
                    {
                        List<VendingMachineItem> list = new List<VendingMachineItem>();

                        for (int i = 0; i < 5; i++)
                        {
                            BeverageItem gum = new BeverageItem(name, price);
                            list.Add(gum);
                        }
                        inventory[slot] = list;

                    }


                }


            }


        }
    }

}

