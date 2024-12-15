// See https://aka.ms/new-console-template for more information

using Classes;

// BankAccount bankAccount = new BankAccount("Jayant", 2000);
var account = new BankAccount("Jayant", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

account.MakeWithdrawl(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid back");
Console.WriteLine(account.Balance);

Console.WriteLine(account.GetAccountHistory());
// Test for a negative balance.
try
{
    account.MakeWithdrawl(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -50);
}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}



