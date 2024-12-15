namespace  Classes;

public class BankAccount
{
    //The account number should be assigned when the object is constructed. But it shouldn't be the responsibility of the caller to create it. The BankAccount class code should know how to assign new account numbers. 

    //The accountNumberSeed is a data member. It's private, which means it can only be accessed by code inside the BankAccount class. It's a way of separating the public responsibilities (like having an account number) from the private implementation (how account numbers are generated). It's also static, which means it's shared by all of the BankAccount objects. The value of a non-static variable is unique to each instance of the BankAccount object. The accountNumberSeed is a private static field and thus has the s_ prefix as per C# naming conventions. The s denoting static and _ denoting private field.
    private static int s_accountNumberSeed = 1234567890;
    public string Number{get;}
    public string Owner{get; set;}
    public decimal Balance{
        get
        {
            decimal balance = 0;
            foreach(var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
        }

    //decimal is a floating point
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        MakeDeposit(initialBalance, DateTime.Now, "initial Balance");
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawl(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawl must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for withdrawl");
        } 
        var withdrawl = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawl);
        
    }
    public string GetAccountHistory()
{
    var report = new System.Text.StringBuilder();

    decimal balance = 0;
    report.AppendLine("Date\t\tAmount\tBalance\tNote");
    foreach (var item in _allTransactions)
    {
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
    }

    return report.ToString();
}
//The below code shows how you use the virtual keyword to declare a method in the base class that a derived class may provide a different implementation for. A virtual method is a method where any derived class may choose to reimplement. The derived classes use the override keyword to define the new implementation. Typically you refer to this as "overriding the base class implementation". The virtual keyword specifies that derived classes may override the behavior. You can also declare abstract methods where derived classes must override the behavior. The base class does not provide an implementation for an abstract method.
public virtual void PerformMonthEndTransactions(){}

}