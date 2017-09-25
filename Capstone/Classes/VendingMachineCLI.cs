using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        private string option_DisplayPurchaseMenu;
        private string option_DisplayVendingMachine;
        private string option_InsertMoney;
        private string option_MakeSelection;
        private string option_Quit;
        private string option_ReturnChange;
        private string option_ReturnToPreviousMenu;
        private List<VendingMachineItem> consumeList = new List<VendingMachineItem>();

        VendingMachine vm = new VendingMachine();

        public void Run()
        {
            PrintTitle();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("Please select from the following options: ");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                string option_DisplayVendingMachine = Console.ReadLine();

                if (option_DisplayVendingMachine == "1")
                {
                    DisplayInventory();
                }
                else if (option_DisplayVendingMachine == "2")
                {
                    DisplayPurchaseMenu();
                }
                else
                {
                    Console.WriteLine("Please select another option");
                }
            }
        }

        public void DisplayInventory()
        {
            string[] slots = vm.Slots;
            for (int i = 0; i < slots.Length; i++)
            {
                if (vm.GetQuantityRemaining(slots[i]) < 1)
                {
                    Console.WriteLine($"{slots[i]} ** SOLD OUT ** {vm.GetItemAtSLot(slots[i]).ItemName} - {vm.GetItemAtSLot(slots[i]).Price.ToString("C")}");
                }

                Console.WriteLine($"{slots[i]} | {vm.GetQuantityRemaining(slots[i].ToString())} - {vm.GetItemAtSLot(slots[i]).ItemName} - {vm.GetItemAtSLot(slots[i]).Price.ToString("C")} ");
            }
        }

        public void DisplayPurchaseMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Purchase Menu");
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("(M) Main Menu");
            Console.WriteLine($"Current Money Provided: {vm.CurrentBalance.ToString("C")}");
            Console.Write("Please select an option: ");
            option_DisplayPurchaseMenu = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {

                if (option_DisplayPurchaseMenu == "1")
                {

                    Console.WriteLine("How much money would you like to deposit?");
                    Console.WriteLine("(1) $1.00");
                    Console.WriteLine("(2) $5.00");
                    Console.WriteLine("(3) $10.00");
                    Console.WriteLine("(4) $20.00");
                    option_InsertMoney = Console.ReadLine();

                    if (option_InsertMoney == "1")
                    {
                        vm.FeedMoney(1);
                        Console.WriteLine($"Current Money Provided: {vm.CurrentBalance.ToString("C")}");
                        TransactionFileLog feedMoney = new TransactionFileLog("Log.txt");
                        feedMoney.RecordDeposit(1, vm.CurrentBalance);
                        Console.WriteLine("Would you like to deposit more money (Y/N)? ");
                        string moreMoney = Console.ReadLine().ToUpper();
                        if (moreMoney == "N")
                        {
                            break; //DisplayPurchaseMenu();
                        }
                    }
                    else if (option_InsertMoney == "2")
                    {
                        vm.FeedMoney(5);
                        Console.WriteLine($"Current Money Provided: {vm.CurrentBalance.ToString("C")}");
                        TransactionFileLog feedMoney = new TransactionFileLog("Log.txt");
                        feedMoney.RecordDeposit(5, vm.CurrentBalance);
                        Console.WriteLine("Would you like to deposit more money (Y/N)? ");
                        string moreMoney = Console.ReadLine().ToUpper();
                        if (moreMoney == "N")
                        {
                            break; // DisplayPurchaseMenu();
                        }

                    }
                    else if (option_InsertMoney == "3")
                    {
                        vm.FeedMoney(10);
                        Console.WriteLine($"Current Money Provided: {vm.CurrentBalance.ToString("C")}");
                        TransactionFileLog feedMoney = new TransactionFileLog("Log.txt");
                        feedMoney.RecordDeposit(10, vm.CurrentBalance);
                        Console.WriteLine("Would you like to deposit more money (Y/N)? ");
                        string moreMoney = Console.ReadLine().ToUpper();
                        if (moreMoney == "N")
                        {
                            break; // DisplayPurchaseMenu();
                        }
                    }
                    else if (option_InsertMoney == "4")
                    {
                        vm.FeedMoney(20);
                        Console.WriteLine($"Current Money Provided: {vm.CurrentBalance.ToString("C")}");
                        TransactionFileLog feedMoney = new TransactionFileLog("Log.txt");
                        feedMoney.RecordDeposit(20, vm.CurrentBalance);
                        Console.WriteLine("Would you like to deposit more money (Y/N)? ");
                        string moreMoney = Console.ReadLine().ToUpper();
                        if (moreMoney == "N")
                        {
                            break; // DisplayPurchaseMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid money option!!");
                    }

                }
                if (option_DisplayPurchaseMenu == "2")
                {
                    Console.WriteLine("Please select a SlotId to purchase: ");
                    Console.WriteLine();
                    string[] slots = vm.Slots;
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (vm.GetQuantityRemaining(slots[i]) < 1)
                        {
                            Console.WriteLine($"{slots[i]} ** SOLD OUT ** {vm.GetItemAtSLot(slots[i]).ItemName} - {vm.GetItemAtSLot(slots[i]).Price.ToString("C")}");
                        }
                        Console.WriteLine($"{slots[i]} | {vm.GetQuantityRemaining(slots[i].ToString())} - {vm.GetItemAtSLot(slots[i]).ItemName} - {vm.GetItemAtSLot(slots[i]).Price.ToString("C")} ");

                    }
                    Console.WriteLine();

                    Console.Write("Selection: ");
                    option_MakeSelection = Console.ReadLine();
                    //consumeList.Add(vm.Purchase(option_MakeSelection));

                    try
                    {
                        if (vm.GetQuantityRemaining(option_MakeSelection.ToString()) == 0)
                        {
                            throw new OutOfStockException("This item is out of stock, please select again!");
                        }
                    }
                    catch(OutOfStockException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }

                    try
                    {
                        if(!vm.inventory.ContainsKey(option_MakeSelection))
                        {
                            throw new InvalidSlotIDException("Invalid selection, please try again!");
                        }
                    }
                    catch(InvalidSlotIDException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }

                    try
                    {
                        if(vm.CurrentBalance < vm.GetItemAtSLot(option_MakeSelection).Price)
                        {
                            throw new InsufficientFundsException($"NO {vm.GetItemAtSLot(option_MakeSelection).ItemName} FOR YOU! Give me more money...");
                        }
                    }
                    catch(InsufficientFundsException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }

                    TransactionFileLog feedMoney = new TransactionFileLog("Log.txt"); //would it work best to put after purchase and make currentBalane+vm.GetItemAtSlot
                    feedMoney.RecordPurchase(vm.GetItemAtSLot(option_MakeSelection).ItemName, option_MakeSelection, vm.CurrentBalance, (vm.CurrentBalance - vm.GetItemAtSLot(option_MakeSelection).Price));
                    vm.Purchase(option_MakeSelection);
                    consumeList.Add(vm.GetItemAtSLot(option_MakeSelection));
                    Console.WriteLine($"You purchased {vm.GetItemAtSLot(option_MakeSelection).ItemName}! ENJOY!!");
                    Console.WriteLine($"Current Balance is: {vm.CurrentBalance}");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to purchase another item (Y/N)? ");
                    string wantAnotherItem = Console.ReadLine().ToUpper();
                    if (wantAnotherItem == "N")
                    {
                        break; //DisplayPurchaseMenu(); 
                    }
                    
                }
                if (option_DisplayPurchaseMenu == "3")
                {

                    TransactionFileLog feedMoney = new TransactionFileLog("Log.txt");
                    feedMoney.RecordCompleteTransaction(vm.CurrentBalance);
                    DisplayChange();
                    vm.ReturnChange();
                    Console.WriteLine("Your current balance is " + vm.CurrentBalance.ToString("C"));

                    for (int i = 0; i < consumeList.Count; i++)
                    {
                        Console.WriteLine("I'm enjoying my " + consumeList[i].itemName + ", " + consumeList[i].Consume()); ///Cant figure why gum prints GLUG GLUG?
                    }
                    Environment.Exit(0) ;
                }
                if (option_DisplayPurchaseMenu == "M")
                {
                    break;
                }

            }
        }

        private void DisplayChange()
        {
            Change changeToReturn = new Change(vm.CurrentBalance);
            Console.WriteLine($"Your change is {changeToReturn.Quarters} quarters, {changeToReturn.Dimes} dimes, {changeToReturn.Nickels} nickels!");
        }


        private void PrintTitle()
        {
            Console.WriteLine("***WELCOME TO THE AMAZING TEDRO-MATIC 500***");
        }
    }
}

