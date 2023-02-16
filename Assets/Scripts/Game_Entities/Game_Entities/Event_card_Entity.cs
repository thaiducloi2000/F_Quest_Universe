using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_card_Entity
{
    public string _id { get; set; }
    public string event_name { get; set; }
    public float cost { get; set; }
    public float down_pay { get; set; }
    public float dept { get; set; }
    public float cash_flow { get; set; }
    public string trading_range { get; set; }
    public string event_description { get; set; }

    public int event_type_id { get; set; }

    public int action { get; set; }

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static Tile_Entity Parse(string json)
    {
        return JsonUtility.FromJson<Tile_Entity>(json);
    }
}
