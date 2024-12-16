﻿// See https://aka.ms/new-console-template for more information

using Classes;

// // BankAccount bankAccount = new BankAccount("Jayant", 2000);
// var account = new BankAccount("Jayant", 1000);
// Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

// account.MakeWithdrawl(500, DateTime.Now, "Rent payment");
// Console.WriteLine(account.Balance);
// account.MakeDeposit(100, DateTime.Now, "Friend paid back");
// Console.WriteLine(account.Balance);

// Console.WriteLine(account.GetAccountHistory());
// // Test for a negative balance.
// try
// {
//     account.MakeWithdrawl(750, DateTime.Now, "Attempt to overdraw");
// }
// catch (InvalidOperationException e)
// {
//     Console.WriteLine("Exception caught trying to overdraw");
//     Console.WriteLine(e.ToString());
// }

// BankAccount invalidAccount;
// try
// {
//     invalidAccount = new BankAccount("invalid", -50);
// }
// catch(ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
//     return;
// }

IntroToClasses();

// <FirstTests>
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawl(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawl(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawl(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());
// </FirstTests>

// <TestLineOfCredit>
var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawl(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawl(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());
// </TestLineOfCredit>
static void IntroToClasses()
{
    var account = new BankAccount("<name>", 1000);
    Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} balance.");

    account.MakeWithdrawl(500, DateTime.Now, "Rent payment");
    Console.WriteLine(account.Balance);
    account.MakeDeposit(100, DateTime.Now, "friend paid me back");
    Console.WriteLine(account.Balance);

    Console.WriteLine(account.GetAccountHistory());

    // Test that the initial balances must be positive:
    try
    {
        var invalidAccount = new BankAccount("invalid", -55);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine("Exception caught creating account with negative balance");
        Console.WriteLine(e.ToString());
    }

    // Test for a negative balance
    try
    {
        account.MakeWithdrawl(750, DateTime.Now, "Attempt to overdraw");
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine("Exception caught trying to overdraw");
        Console.WriteLine(e.ToString());
    }
}


