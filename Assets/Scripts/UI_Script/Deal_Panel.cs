using UnityEngine;
using TMPro;


public class Deal_Panel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Cost_Txt;
    [SerializeField] private TextMeshProUGUI Mortgage_Divined_Txt;
    [SerializeField] private TextMeshProUGUI CashFlow_TradingRange_Txt;
    [SerializeField] private TextMeshProUGUI DownSize_Share_Owned_Txt;


    public void SetBigDeal(Big_Deal deal)
    {
        this.Title.text = deal.Title;
        this.Description.text = deal.Description;
        this.Cost_Txt.text = "Cost : " + deal.Cost;
        this.Mortgage_Divined_Txt.text = "Divined : " + deal.Dividend;
        this.CashFlow_TradingRange_Txt.text = "Trading Range : " + deal.TradingRange;
        this.DownSize_Share_Owned_Txt.text = "Share Owned : " + deal.Share_Owned;

    }

    public void SetSmallDeal(Small_Deal deal)
    {
        this.Title.text = deal.Title;
        this.Description.text = deal.Description;
        this.Cost_Txt.text = "Cost : " + deal.Cost.ToString();
        this.Mortgage_Divined_Txt.text = "Divined : " + deal.Mortgage;
        this.CashFlow_TradingRange_Txt.text = "Trading Range : " + deal.Cash_flow;
        this.DownSize_Share_Owned_Txt.text = "Share Owned : " + deal.Downsize;
    }
    
}
