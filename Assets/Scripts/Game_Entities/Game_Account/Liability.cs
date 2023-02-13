
public class Liability : GameAccount
{
    public Liability(string gameaccount_name, float gameaccount_money)
    {
        this.AccountType = AccountType.Liability;
        this.Gameaccount_name = gameaccount_name;
        this.Gameaccount_money = gameaccount_money;
    }

    public override float Account_Balance()
    {
        return -base.Account_Balance();
    }
}
