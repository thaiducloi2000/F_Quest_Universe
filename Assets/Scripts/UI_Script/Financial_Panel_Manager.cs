using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Financial_Panel_Manager : MonoBehaviour
{
    [SerializeField] private GameObject financial;
    public bool isOpen = false;

    [SerializeField] private Financial financial_rp;






    public void viewFinancial()
    {
        isOpen = !isOpen;
        this.financial.SetActive(isOpen);
        this.financial.GetComponent<Financial_Panel>().loadFinInformation(this.financial_rp);
    }

    public void Financial(Financial fin)
    {
        this.financial_rp = fin;
    }
}
