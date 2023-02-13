using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Job_Panel : MonoBehaviour
{
    [SerializeField] private GameObject account_field;
    [SerializeField] private GameObject Job_Name;
    [SerializeField] private GameObject Content_Incomes;
    [SerializeField] private GameObject Content_Assets;
    [SerializeField] private GameObject Content_Expenses;
    [SerializeField] private GameObject Content_Liabilities;
    [SerializeField] private TextMeshProUGUI total_Income;
    [SerializeField] private TextMeshProUGUI total_Asset;
    [SerializeField] private TextMeshProUGUI total_Expense;
    [SerializeField] private TextMeshProUGUI total_Liabilities;
    public Job job;

    public void loadJobInformation(Job job)
    {
        float total_income = 0;
        float total_asset = 0;
        float total_expense = 0;
        float total_liability = 0;
        foreach (Income inc in job.incomes)
        {
            Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += inc.Gameaccount_name + ": $" + inc.Gameaccount_money+'\n';
            total_income += inc.Gameaccount_money;
        }
        foreach (Asset asset in job.assets)
        {
            Content_Assets.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += asset.Gameaccount_name + ": $" + asset.Gameaccount_money + '\n';
            total_asset+= asset.Gameaccount_money;
        }
        foreach(Expense expense in job.expenses)
        {
            Content_Expenses.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += expense.Gameaccount_name + ": $" + expense.Gameaccount_money + '\n';
            total_expense += expense.Gameaccount_money;
        }
        foreach (Liability liability in job.liabilities)
        {
            Content_Liabilities.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += liability.Gameaccount_name + ": $" + liability.Gameaccount_money + '\n';
            total_liability += liability.Gameaccount_money;
        }
        this.job = new Job(job);
        total_Income.text = "Tong Thu Nhap: " + total_income;
        total_Asset.text = "Tong Tai San: " + total_asset;
        total_Expense.text = "Tong Chi Phi: " + total_expense;
        total_Liabilities.text = "Tong No : " + total_liability;
    }
}
