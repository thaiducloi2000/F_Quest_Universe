
public class Market : Deal
{
    public Market(string title, string description, float cost,int Action)
    {
        base.Type = Deal_Type.Doodad;
        base.Title = title;
        base.Description = description;
        base.Cost = cost;
        base.Action = Action;
    }
}
