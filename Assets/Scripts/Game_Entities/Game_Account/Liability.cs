
public class Liability : Game_accounts
{
    public Liability(string gameaccount_name, float gameaccount_money)
    {
        this.Game_account_type = AccountType.Liability;
        this.Game_account_name = gameaccount_name;
        this.Game_account_value = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return -base.Account_Balance();
    }
}
