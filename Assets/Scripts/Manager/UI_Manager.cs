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
    public GameObject Financial_Panel;
    public GameObject Market_Panel;
    public GameObject Doodad_Panel;
    public GameObject Roll_Button;
    private int b_deal = -1;
    private int s_deal = -1;
    [SerializeField] Player player;

    private void Start()
    {
        UnAcctiveAllPanel();
        if(player == null)
        {
            
            player = GetComponentInParent<Player>();
        }
    }

    //private void Update()
    //{
        
    //}


    public void PopupJob_UI(Job job)
    {
        Job_Panel.GetComponent<Job_Panel>().loadJobInformation(job);
    }

    private void UnAcctiveAllPanel()
    {
        Deal_Panel.SetActive(false);
        Select_Deal_Type_Panel.SetActive(false);
        Doodad_Panel.SetActive(false);
        Market_Panel.SetActive(false);
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
        
        if(b_deal >= 0 /* && (player.financial_rp.GetCash() >= EvenCard_Data.instance.Big_Deal_List[b_deal].Cost || player.financial_rp.GetCash() >= EvenCard_Data.instance.Big_Deal_List[b_deal].Downpay)*/)
        {
            //player.MoveToFatRace();
            ApplyBigDeal(EvenCard_Data.instance.Big_Deal_List[b_deal]);
        }
        else if (s_deal >= 0 /*&& player.financial_rp.GetCash() >= EvenCard_Data.instance.Small_Deal_List[s_deal].Cost || player.financial_rp.GetCash() >= EvenCard_Data.instance.Small_Deal_List[s_deal].Downsize*/)
        {
            //player.MoveToFatRace();
            ApplySmallDeal(EvenCard_Data.instance.Small_Deal_List[s_deal],1);
        }
        if (player.financial_rp.GetPassiveIncome() && player.isInFatRace == false)
        {

            player.isInFatRace = player.financial_rp.GetPassiveIncome();
            player.MoveToFatRace();
        }
        Deal_Panel.SetActive(false);
        Reset_Deal();
    }

    public void Popup_Market_Panel(Market market)
    {
        Market_Panel.SetActive(true);

        Market_Panel panel = Market_Panel.GetComponent<Market_Panel>();
        panel.SetMarketPanel(market);
    }

    public void Popup_Doodad_Panel(Doodad doodad)
    {
        Doodad_Panel.SetActive(true);

        Doodad_Panel panel = Doodad_Panel.GetComponent<Doodad_Panel>();
        panel.SetDoodadPanel(doodad);
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

    private void ApplyBigDeal(Big_Deal deal)
    {
        switch (deal.Action)
        {
            case 1:
                if (deal.Downpay > 0)
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Downpay);
                }
                else if (deal.Downpay == deal.Cost)
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Downpay);
                }
                else
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Cost);
                }
                // Add Game Account
                if (deal.Cash_flow == 0)
                {
                    Asset game_Accounts = new Asset(deal.Account_Name, deal.Cost,1);
                    player.financial_rp.game_accounts.Add(game_Accounts);
                }
                else if (deal.Cash_flow > 0 && deal.Downpay < deal.Cost)
                {
                    Income income = new Income(deal.Account_Name, deal.Cash_flow,1);
                    Liability lia = new Liability(deal.Account_Name, deal.Dept,1);
                    Asset asset = new Asset(deal.Account_Name, deal.Cost,1);
                    player.financial_rp.game_accounts.Add(income);
                    player.financial_rp.game_accounts.Add(lia);
                    player.financial_rp.game_accounts.Add(asset);
                }
                break;
            case 3:
                //foreach (Game_accounts game_accounts in player.financial_rp.game_accounts)
                //{
                //    if (game_accounts.Game_account_name.Contains(deal.Account_Name))
                //    {
                        player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Cost);
                //    }
                //}
                break;
            case 4:
                foreach(Game_accounts game_accounts in player.financial_rp.game_accounts)
                {
                    if(game_accounts.Game_account_name.Contains(deal.Account_Name))
                    {
                        game_accounts.Game_account_value /= 2;
                    }
                }
                break;
            case 5:
                foreach (Game_accounts game_accounts in player.financial_rp.game_accounts)
                {
                    if (game_accounts.Game_account_name.Contains(deal.Account_Name))
                    {
                        game_accounts.Game_account_value *= 2;
                    }
                }
                break;
            default:
                break;
        }
    }

    private void ApplySmallDeal(Small_Deal deal,int amount)
    {
        switch (deal.Action)
        {
            case 1:

                // check Down Pay - > Cost
                if(deal.Downsize > 0)
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Downsize * amount);
                }else if(deal.Downsize == deal.Cost)
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Downsize*amount);
                }
                else
                {
                    player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Cost*amount);
                }
                // Add Game Account
                if (deal.Cash_flow == 0)
                {
                    Asset game_Accounts = new Asset(deal.Account_Name, deal.Cost, amount);
                    player.financial_rp.game_accounts.Add(game_Accounts);
                }else if(deal.Cash_flow > 0 && deal.Downsize < deal.Cost)
                {
                    Income income = new Income(deal.Account_Name, deal.Cash_flow, amount);
                    Liability lia = new Liability(deal.Account_Name, deal.Dept, amount);
                    Asset asset = new Asset(deal.Account_Name, deal.Cost, amount);
                    player.financial_rp.game_accounts.Add(income);
                    player.financial_rp.game_accounts.Add(lia);
                    player.financial_rp.game_accounts.Add(asset);
                }
                break;
            case 3:
                foreach (Game_accounts game_accounts in player.financial_rp.game_accounts)
                {
                    if (game_accounts.Game_account_name.Contains(deal.Account_Name))
                    {
                        player.financial_rp.SetCash(player.financial_rp.GetCash() - deal.Cost);
                    }
                }
                break;
            case 4:
                foreach (Game_accounts game_accounts in player.financial_rp.game_accounts)
                {
                    if (game_accounts.Game_account_name.Contains(deal.Account_Name))
                    {
                        game_accounts.Game_account_value /= 2;
                    }
                }
                break;
            case 5:
                foreach (Game_accounts game_accounts in player.financial_rp.game_accounts)
                {
                    if (game_accounts.Game_account_name.Contains(deal.Account_Name))
                    {
                        game_accounts.Game_account_value *= 2;
                    }
                }
                break;
            default:
                break;
        }
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
