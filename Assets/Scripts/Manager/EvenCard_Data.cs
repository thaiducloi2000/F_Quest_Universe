using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static Event_card_Entity;

public class EvenCard_Data : MonoBehaviour
{
    public static EvenCard_Data instance;
    [SerializeField] public List<Small_Deal> Small_Deal_List;
    [SerializeField] public List<Big_Deal> Big_Deal_List;
    [SerializeField] public List<Doodad> Doodads;
    [SerializeField] public List<Market> Markets;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
        LoadAllDeal();
    }

    private void Start()
    {
    }

    private void LoadAllDeal()
    {
        // load all Deal from db
        Server_Connection_Helper helper = new Server_Connection_Helper();
        Small_Deal_List = new List<Small_Deal>();
        Big_Deal_List = new List<Big_Deal>();
        Doodads = new List<Doodad>();
        Markets = new List<Market>();
        StartCoroutine(helper.Get("EventCards/event", (request,process) =>
        {
            List<Event_card_Entity> event_card = ParseJsonToListEventCard(request);
            Debug.Log(string.Format("Downloaded Event Card Process {0:P1}", process * 100f + "%"));
            foreach (Event_card_Entity card in event_card)
            {
                switch (card.event_type_id)
                {
                    case 1:
                        LoadBigDeal(card);
                        break;
                    case 2:
                        LoadSmallDeal(card);
                        break;
                    case 3:
                        LoadDoodad(card);
                        break;
                    case 4:
                        LoadMarket(card);
                        break;
                    default:
                        break;
                }
            }
        }
        ));

    }

    private List<Event_card_Entity> ParseJsonToListEventCard(UnityWebRequest webRequest)
    {
        List<Event_card_Entity> list= new List<Event_card_Entity>();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(webRequest.downloadHandler.text);
                list = JsonConvert.DeserializeObject<List<Event_card_Entity>>(webRequest.downloadHandler.text);
                break;
            default:
                break;
        }
        return list;
    }

    private void LoadDoodad(Event_card_Entity card)
    {
        Doodads.Add(new Doodad(card.event_name, card.event_description, card.cost,card.action));
    }


    private void LoadMarket(Event_card_Entity card)
    {
        Markets.Add(new Market(card.event_name, card.event_description, card.cost,card.action));
    }

    private void LoadBigDeal(Event_card_Entity card)
    {
        Big_Deal_List.Add(new Big_Deal(card.event_name, card.event_description, card.cost, card.down_pay, card.trading_range, card.cash_flow,card.action));
    }

    private void LoadSmallDeal(Event_card_Entity card)
    {   
        Small_Deal_List.Add(new Small_Deal(card.event_name, card.event_description, card.cost, card.dept, card.cash_flow, card.down_pay,card.action));
    }
}
