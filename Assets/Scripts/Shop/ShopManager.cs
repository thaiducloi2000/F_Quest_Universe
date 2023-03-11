using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItemSO[] shopItemSO;
    public ShopTemplate[] shopTemplate;
    public GameObject[] shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemSO.Length; i++)   
            shopPanel[i].SetActive(true);
        loadTemplate();

    }

    public void loadTemplate()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopTemplate[i].nameitem_inputfield.text = shopItemSO[i].name;
            shopTemplate[i].price_inputfield.text = shopItemSO[i].price.ToString();
        }
    }
}
