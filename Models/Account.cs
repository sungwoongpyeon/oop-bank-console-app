namespace BankConoleApp.Models
{
    /*
     * Abstract class for Account
     * Polymorphism
     * Encapsulation
     * Inheritance
    Polymorphism is the ability of a class to take multiple forms. In C#, polymorphism is achieved through method overriding and method overloading.

    In this Bank example, polymorphism is evident in the following ways:

    Method Overriding: The CalculateInterest() method is marked as virtual in the Account class, and it is overridden 
                       in the derived classes SavingsAccount and CheckingAccount. 
                       Each derived class provides its own specific implementation of the CalculateInterest() method. 
                       This allows the ProcessTransactions() method in the Bank class to call the CalculateInterest() method on each account object 
                       without needing to know the specific type of the account. 

    Method Overloading: The Deposit() and Withdraw() methods in the Account class are overloaded to accept different parameter types (amounts to be deposited or withdrawn). 
                        This allows clients to call these methods with different data types without having to worry about the internal implementation details. 
                        The Bank class can use these methods polymorphically on account objects.
    
    => It will automatically use the appropriate implementation based on the actual type of the object. 
    */
    public abstract class Account
    {
        private int accountNumber;
        private string accountHolder;
        protected double balance;

        public int AccountNumber { get => accountNumber; }
        public string AccountHolder { get => accountHolder; }

        public Account(int accountNumber, string accountHolder)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = 0;
        }

        /// <summary>
        /// In C#, the virtual keyword is used to indicate that a method in a base class can be overridden in derived classes. 
        /// It enables polymorphism, which allows a derived class to provide its own implementation of the method while still adhering 
        /// to the method's signature defined in the base class.
        /// In the provided code snippet, the Deposit method is marked as virtual. 
        /// This means that this method can be overridden in a derived class (a class that inherits from the current class). 
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"{AccountHolder}'s account ({AccountNumber}) deposited ${amount}. New balance: ${balance}");
        }

        /// <summary>
        /// Method Overloading
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Deposit(int amount)
        {
            Deposit((double)amount);
        }

        public virtual void Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"{AccountHolder}'s account ({AccountNumber}) withdrew ${amount}. New balance: ${balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient balance in {AccountHolder}'s account ({AccountNumber}). Current balance: ${balance}");
            }
        }

        /// <summary>
        /// Method Overloading
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Withdraw(int amount)
        {
            Withdraw((double)amount);
        }

        public abstract void CalculateInterest();

        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Balance: ${balance}");
        }
    }

    // Savings Account - Inherits from Account
    public class SavingsAccount : Account
    {
        public SavingsAccount(int accountNumber, string accountHolder) : base(accountNumber, accountHolder)
        {
        }

        public override void CalculateInterest()
        {
            double interestRate = 0.02; // 2% interest rate
            double interest = balance * interestRate;
            balance += interest;
            Console.WriteLine($"{AccountHolder}'s savings account ({AccountNumber}) earned ${interest} interest. New balance: ${balance}");
        }

        public override void Deposit(int amount)
        {
            // Custom implementation for Deposit in SavingsAccount
            // For example, you may impose some restrictions or rules for depositing in a savings account.
            // You can call the base.Deposit(amount) to use the base class implementation before applying custom logic.
            // This ensures that the balance is updated correctly and the custom behavior is added on top of the base behavior.
            base.Deposit(amount);
            // Additional logic for SavingsAccount deposit
        }
    }

    // Checking Account - Inherits from Account
    public class CheckingAccount : Account
    {
        public CheckingAccount(int accountNumber, string accountHolder) : base(accountNumber, accountHolder)
        {
        }

        public override void CalculateInterest()
        {
            Console.WriteLine($"{AccountHolder}'s checking account ({AccountNumber}) doesn't earn interest.");
        }

        public override void Deposit(double amount)
        {
            // Custom implementation for Deposit in SavingsAccount
            // For example, you may impose some restrictions or rules for depositing in a savings account.
            // You can call the base.Deposit(amount) to use the base class implementation before applying custom logic.
            // This ensures that the balance is updated correctly and the custom behavior is added on top of the base behavior.
            base.Deposit(amount);
            // Additional logic for SavingsAccount deposit
        }
    }
}
