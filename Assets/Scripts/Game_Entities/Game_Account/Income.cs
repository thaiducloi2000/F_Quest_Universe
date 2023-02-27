
public class Income : game_accounts
{
    public Income(string gameaccount_name, float gameaccount_money)
    {
        this.gameAccount_type = AccountType.Income;
        this.gameAccount_name = gameaccount_name;
        this.gameAccount_cost = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return base.Account_Balance();
    }
}
