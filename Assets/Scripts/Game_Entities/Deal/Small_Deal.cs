
public class Small_Deal : Deal
{
    private float mortgage;
    private float cash_flow;
    private float downsize;

    public Small_Deal(string title,string Account_Name, string description, float cost, float mortgage, float cash_flow, float downsize, int Action)
    {
        this.Type = Deal_Type.Small;
        this.Title = title;
        this.Account_Name = Account_Name;
        this.Description = description;
        this.Cost = cost;
        this.Mortgage = mortgage;
        this.Downsize = downsize;
        this.Action = Action;
        this.cash_flow = cash_flow;
    }

    public float Mortgage { get => mortgage; set => mortgage = value; }
    public float Cash_flow { get => cash_flow; set => cash_flow = value; }
    public float Downsize { get => downsize; set => downsize = value; }
}
