namespace Classes;

public class LineOfCreditAccount:BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance):base(name, initialBalance)
    {
        
    }

    public override void PerformMonthEndTransactions()
    {
        if(Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawl(interest, DateTime.Now, "charge monthly interest");
        }
    }
}