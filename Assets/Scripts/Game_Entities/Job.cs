using System.Collections.Generic;


public class Job
{
    public string _id { get; set; }
    public string name { get; set; }
    public float children_cost{ get; set; }
    public List<game_accounts> game_accounts { get; set; }

    public Job(string _id, string name, float children_cost, List<game_accounts> gameAccounts)
    {
        this.game_accounts = gameAccounts;
        this._id = _id;
        this.name = name;
        this.children_cost = children_cost;
    }

}
