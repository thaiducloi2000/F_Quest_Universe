
using UnityEngine;
public class Deal
{

    public enum Deal_Type { Big, Small, Doodad, Market };
    private Deal_Type type;
    private string title;
    private string account_Name;
    private string description;
    private float cost;
    private int action;


    public Deal_Type Type { get => type; set => type = value; }
    public string Title { get => title; set => title = value; }

    public string Account_Name { get => account_Name; set => account_Name = value; }
    public string Description { get => description; set => description = value; }
    public float Cost { get => cost; set => cost = value; }
    public int Action { get => action; set => action = value; }
}
