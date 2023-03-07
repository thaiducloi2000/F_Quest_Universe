
public class Big_Deal : Deal
{
    private float dividend;
    private string tradingRange;
    private float share_Owned;
    private float cash_flow;

    public Big_Deal(string title,string Account_name,string description,float cost,float dividend, string tradingRange, float share_Owned,float cash_flow,int Action)
    {
        this.Type = Deal_Type.Big;
        this.Title = title;
        this.Account_Name = Account_name;
        this.Description = description;
        this.Cost = cost;
        this.dividend = dividend;
        this.tradingRange = tradingRange;
        this.share_Owned = share_Owned;
        this.Cash_flow = cash_flow;
        this.Action = Action;
    }


    public float Dividend { get => dividend; set => dividend = value; }
    public string TradingRange { get => tradingRange; set => tradingRange = value; }
    public float Share_Owned { get => share_Owned; set => share_Owned = value; }
    public float Cash_flow { get => cash_flow; set => cash_flow = value; }
}
