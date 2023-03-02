

public class Asset : Game_accounts
{
    public Asset(string gameaccount_name,float gameaccount_money)
    {
        this.Game_account_type = AccountType.Asset;
        this.Game_account_name = gameaccount_name;
        this.Game_account_value = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return +base.Account_Balance();
    }
}
