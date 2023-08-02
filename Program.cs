using BankConoleApp.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank();

        Console.WriteLine("Welcome to the Console Bank!");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Create Savings Account");
            Console.WriteLine("2. Create Checking Account");
            Console.WriteLine("3. Perform Account Transactions");
            Console.WriteLine("0. Exit");

            int choice = bank.GetChoice();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the account holder's name: ");
                    string savingsAccountHolder = Console.ReadLine();
                    Console.Write("Enter the account number: ");
                    int savingsAccountNumber = bank.GetChoice();
                    bank.AddAccount(new SavingsAccount(savingsAccountNumber, savingsAccountHolder));
                    break;

                case 2:
                    Console.Write("Enter the account holder's name: ");
                    string checkingAccountHolder = Console.ReadLine();
                    Console.Write("Enter the account number: ");
                    int checkingAccountNumber = bank.GetChoice();
                    bank.AddAccount(new CheckingAccount(checkingAccountNumber, checkingAccountHolder));
                    break;

                case 3:
                    bank.ProcessTransactions();
                    break;

                case 0:
                    Console.WriteLine("Thank you for using the Console Bank. Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}