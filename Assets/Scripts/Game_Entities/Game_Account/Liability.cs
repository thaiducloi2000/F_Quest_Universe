
public class Liability : game_accounts
{
    public Liability(string gameaccount_name, float gameaccount_money)
    {
        this.gameAccount_type = AccountType.Liability;
        this.gameAccount_name = gameaccount_name;
        this.gameAccount_cost = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return -base.Account_Balance();
    }
}
