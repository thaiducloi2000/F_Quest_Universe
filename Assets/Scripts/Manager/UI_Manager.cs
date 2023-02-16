using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// Manage UI Canvas in Game
public class UI_Manager : MonoBehaviour
{

    public GameObject Deal_Panel;
    public GameObject Select_Deal_Type_Panel;
    public GameObject Job_Panel;
    private int b_deal = -1;
    private int s_deal = -1;
    [SerializeField] Player player;

    private void Start()
    {
        UnAcctiveAllPanel();
    }


    public void PopupJob_UI(Job job)
    {
        Job_Panel.GetComponent<Job_Panel>().loadJobInformation(job);
    }

    private void UnAcctiveAllPanel()
    {
        Deal_Panel.SetActive(false);
        Select_Deal_Type_Panel.SetActive(false);
        Job_Panel.SetActive(true);
    }

    public void PopUpDeal_UI()
    {
        // Open Select Deal Type first
        Select_Deal_Type_Panel.SetActive(true);

    }

    public void AcceptJob()
    {
        this.Job_Panel.SetActive(false);
    }
    public void Denine_Deal_Btn()
    {
        Deal_Panel.SetActive(false);
        Reset_Deal();
    }

    public void Accept_Deal_Btn()
    {
        
        if(b_deal >= 0)
        {
            player.MoveToFatRace();
        }
        else if (s_deal >= 0)
        {
            player.MoveToFatRace();
        }
        Deal_Panel.SetActive(false);
        Reset_Deal();
    }


    public void Big_Deal_Btn()
    {
        Select_Deal_Type_Panel.SetActive(false);
        Deal_Panel.SetActive(true);

        // Get BIg Deal From Instance
        Deal_Panel panel = Deal_Panel.GetComponent<Deal_Panel>();
        int deal_num = Random.Range(0, EvenCard_Data.instance.Big_Deal_List.Count-1);
        Big_Deal deal = EvenCard_Data.instance.Big_Deal_List[deal_num];
        panel.SetBigDeal(deal);
        b_deal = deal_num;
    }
    public void Small_Deal_Btn()
    {
        Select_Deal_Type_Panel.SetActive(false);
        Deal_Panel.SetActive(true);


        // Get Small Deal From Instance
        Deal_Panel panel = Deal_Panel.GetComponent<Deal_Panel>();
        int deal_num = Random.Range(0, EvenCard_Data.instance.Small_Deal_List.Count-1);
        Small_Deal deal = EvenCard_Data.instance.Small_Deal_List[deal_num];
        panel.SetSmallDeal(deal);
        s_deal = deal_num;
        
    }


    private void Reset_Deal()
    {
        this.s_deal = -1;
        this.b_deal = -1;
    }
}
