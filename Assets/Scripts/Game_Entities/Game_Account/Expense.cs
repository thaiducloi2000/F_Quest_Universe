
public class Expense : game_accounts
{
    public Expense(string gameaccount_name, float gameaccount_money)
    {
        this.gameAccount_type = AccountType.Expense;
        this.gameAccount_name = gameaccount_name;
        this.gameAccount_cost = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return -base.Account_Balance();
    }
}
