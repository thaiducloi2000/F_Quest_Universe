using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Financial_Panel : MonoBehaviour
{
    [SerializeField] private GameObject Job_Name;
    [SerializeField] private GameObject Content_Incomes;
    [SerializeField] private GameObject Content_Assets;
    [SerializeField] private GameObject Content_Expenses;
    [SerializeField] private GameObject Content_Liabilities;

    public void loadFinInformation(Financial fin)
    {
        resetText();
        float total_income = 0;
        float total_asset = 0;
        float total_expense = 0;
        float total_liability = 0;
        Job_Name.GetComponent<TextMeshProUGUI>().text = fin.job_card_id;
        foreach (Game_accounts account in fin.game_accounts)
        {
            switch (account.Game_account_type)
            {
                case AccountType.Income:
                    if (account.Game_account_name != "Salary")
                    {
                        Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    }
                    else
                    {
                        Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Amount + " " + account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    }
                    total_income += account.Game_account_value;
                    break;
                case AccountType.Asset:
                    if (account.Game_account_name != "cash")
                    {
                        Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    }
                    else
                    {
                        Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Amount + " " + account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    }
                    total_asset += account.Game_account_value;
                    break;
                case AccountType.Expense:
                    Content_Expenses.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    total_expense += account.Game_account_value;
                    break;
                case AccountType.Liability:
                    Content_Liabilities.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text += account.Game_account_name + ": $" + account.Game_account_value + '\n';
                    total_liability += account.Game_account_value;
                    break;
                default:
                    break;
            }
        }
        //total_Income.text = "Tong Thu Nhap: " + total_income;
        //total_Asset.text = "Tong Tai San: " + total_asset;
        //total_Expense.text = "Tong Chi Phi: " + total_expense;
        //total_Liabilities.text = "Tong No : " + total_liability;
    }

    private void resetText()
    {
        Content_Incomes.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text = "";
        Content_Assets.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text = "";
        Content_Expenses.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text = "";
        Content_Liabilities.GetComponent<ScrollRect>().content.GetComponentInChildren<TextMeshProUGUI>().text = "";
        //total_Income.text = "";
        //total_Asset.text = "";
        //total_Expense.text = "";
        //total_Liabilities.text = "";

    }

}
