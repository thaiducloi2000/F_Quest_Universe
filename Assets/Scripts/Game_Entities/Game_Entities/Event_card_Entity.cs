using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_card_Entity
{
    public string _id { get; set; }
    public string Event_name { get; set; }
    public float Cost { get; set; }
    public float Down_pay { get; set; }
    public float Dept { get; set; }
    public float Cash_flow { get; set; }
    public string Trading_range { get; set; }
    public string Event_description { get; set; }


    public int Event_type_id { get; set; }

    public int Action_id { get; set; }

    //public string Stringify()
    //{
    //    return JsonUtility.ToJson(this);
    //}

    //public static Tile_Entity Parse(string json)
    //{
    //    return JsonUtility.FromJson<Tile_Entity>(json);
    //}
}
