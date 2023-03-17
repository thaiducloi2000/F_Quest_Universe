
using TMPro;
using UnityEngine;

public class Market_Panel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Cost_Txt;
    public Market market;
    [SerializeField] private Player player;


    public void SetMarketPanel(Market market)
    {
        this.market = market;
        this.Title.text = market.Title;
        this.Description.text = market.Description;
        if(market.Cost > 0)
        {
            this.Cost_Txt.text = "Cost : " + market.Cost + "$ / 1 Unit";
        }

    }

    public void AcceptMarket()
    {
        foreach(Game_accounts account in this.player.financial_rp.game_accounts)
        {
            if(account.Game_account_name == market.Account_Name)
            {
                switch (market.Action)
                {
                    case 2:
                        player.financial_rp.game_accounts.Remove(account);
                        player.financial_rp.SetCash(player.financial_rp.GetCash() + market.Cost);
                        break;
                    case 4:
                        account.Game_account_value *= 2;
                        break;
                    case 7:
                        if (market.Cost == 0)
                        {
                            account.Game_account_value *= 2;
                        }
                        else
                        {
                            account.Game_account_value = market.Cost;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        this.gameObject.SetActive(false);
    }


}
