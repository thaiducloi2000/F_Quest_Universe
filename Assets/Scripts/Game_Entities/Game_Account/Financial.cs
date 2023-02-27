
using System.Collections.Generic;

public class Financial
{
    public int children_amount { get; set; }
    public string user_id { get; set; }
    public string job_card_id { get; set; }
    public float income_per_month { get; set; }
    public float expense_per_month { get; set; }
    public List<game_accounts> game_accounts { get; set; }

    public Financial(int children_amount, string user_id, string job_card_id, float income_per_month, float expense_per_month, List<game_accounts> game_accounts)
    {
        this.children_amount = children_amount;
        this.user_id = user_id;
        this.job_card_id = job_card_id;
        this.income_per_month = income_per_month;
        this.expense_per_month = expense_per_month;
        this.game_accounts = game_accounts;
    }

    public float GetCash()
    {
        float cash = 0;
        foreach (game_accounts accounts in game_accounts)
        {
            if (accounts.gameAccount_type == AccountType.Asset && accounts.gameAccount_name == "Tiền mặt")
            {
                cash = accounts.gameAccount_cost;
            }
        }
        return cash;
    }
    public void SetCash(float cash)
    {
        foreach (game_accounts accounts in game_accounts)
        {
            if (accounts.gameAccount_type == AccountType.Asset && accounts.gameAccount_name == "Tiền mặt")
            {
                accounts.gameAccount_cost = cash;
            }
        }
    }


}
