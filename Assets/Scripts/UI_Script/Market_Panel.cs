
using TMPro;
using UnityEngine;

public class Market_Panel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Cost_Txt;
    public Market market;

    public void SetMarketPanel(Market market)
    {
        this.market = market;
        this.Title.text = market.Title;
        this.Description.text = market.Description;
        this.Cost_Txt.text = "Cost : " + market.Cost +"$/1 Unit";

    }

    public void AcceptMarket()
    {
        //Player player = GetComponentInChildren<Player>();
        this.gameObject.SetActive(false);
    }


}
