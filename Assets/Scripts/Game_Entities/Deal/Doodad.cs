
public class Doodad : Deal
{
    // Start is called before the first frame update
    public Doodad(string title, string description, float cost,int Action)
    {
        base.Type = Deal_Type.Doodad;
        base.Title= title;
        base.Description= description;
        base.Cost= cost;
        base.Action = Action;
    }
}
