namespace BankConoleApp.Models
{
    public class Bank
    {
        private Account[] accounts;
        private int accountCount;

        public Bank()
        {
            accounts = new Account[10]; // assuming 10 accounts
            accountCount = 0;
        }

        public void AddAccount(Account account)
        {
            if (accountCount < accounts.Length)
            {
                accounts[accountCount] = account;
                accountCount++;
                Console.WriteLine($"Account for {account.AccountHolder} added successfully!");
            }
            else
            {
                Console.WriteLine("Bank cannot create more accounts. Limit reached.");
            }
        }

        public void ProcessTransactions()
        {
            foreach (var account in accounts)
            {
                if (account != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Processing transactions for {account.AccountHolder}'s account ({account.AccountNumber})");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Calculate Interest");
                    Console.WriteLine("4. View Account Details");
                    Console.WriteLine("0. Exit");

                    int choice = GetChoice();
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the amount to deposit: $");
                            double depositAmount = GetAmount();
                            account.Deposit(depositAmount);
                            break;

                        case 2:
                            Console.Write("Enter the amount to withdraw: $");
                            double withdrawAmount = GetAmount();
                            account.Withdraw(withdrawAmount);
                            break;

                        case 3:
                            account.CalculateInterest();
                            break;

                        case 4:
                            account.DisplayAccountInfo();
                            break;

                        case 0:
                            Console.WriteLine("Exiting from account transactions.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        public int GetChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
            }
            return choice;
        }

        public double GetAmount()
        {
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }
            return amount;
        }
    }
}
