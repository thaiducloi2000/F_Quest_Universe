
public enum AccountType { Income,Expense,Asset,Liability}
public class GameAccount 
{
    private AccountType accountType;
    private string gameaccount_name;
    private float gameaccount_money;

    public AccountType AccountType { get => accountType; set => accountType = value; }
    public string Gameaccount_name { get => gameaccount_name; set => gameaccount_name = value; }
    public float Gameaccount_money { get => gameaccount_money; set => gameaccount_money = value; }

    public virtual float Account_Balance()
    {
        return this.gameaccount_money;
    }

}
