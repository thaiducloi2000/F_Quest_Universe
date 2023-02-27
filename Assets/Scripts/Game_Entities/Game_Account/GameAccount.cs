
public enum AccountType { Income,Expense,Asset,Liability}
public class game_accounts
{
    public AccountType gameAccount_type { get; set; }
    public string gameAccount_name { get; set; }
    public float gameAccount_cost { get; set; }


    public virtual float Account_Balance()
    {
        return this.gameAccount_cost;
    }

}
