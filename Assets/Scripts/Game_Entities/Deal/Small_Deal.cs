
public class Small_Deal : Deal
{
    private float mortgage;
    private float cashflow;
    private float downsize;

    public Small_Deal(string title, string description, float cost, float mortgage, float cashflow, float downsize, int Action)
    {
        this.Type = Deal_Type.Small;
        this.Title = title;
        this.Description = description;
        this.Cost = cost;
        this.Mortgage = mortgage;
        this.Cashflow = cashflow;
        this.Downsize = downsize;
        this.Action = Action;
    }

    public float Mortgage { get => mortgage; set => mortgage = value; }
    public float Cashflow { get => cashflow; set => cashflow = value; }
    public float Downsize { get => downsize; set => downsize = value; }
}
