using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
// Move Player base on Dice
public class Step : MonoBehaviour
{
    public int currentPos; // Current Pos of Player in GameBoard list...
    public Player player;



    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public IEnumerator Move(Player player, int step,List<GameObject> race)
    {
        if (GameManager.Instance.isPlayerMoving)
        {
            yield break;
        }
        GameManager.Instance.isPlayerMoving = true;

        while (step > 0)
        {
            currentPos++;
            currentPos %= race.Count;
            Vector3 nextPos = race[this.currentPos].transform.position;
            if (race[this.currentPos].GetComponent<Tile>().Type == TileType.PayCheck)
            {
                Paycheck();
            }
            nextPos.y = 0.25f;
            while (MoveToNextTiles(nextPos, player)) { yield return null; }
            yield return new WaitForSeconds(.2f);
            step--;
        }
        GameManager.Instance.isPlayerMoving = false;

        // popup panel when player stop moving 
        PopupPanel(race[this.currentPos].GetComponent<Tile>());
    }


    public IEnumerator MoveFatRace(Player player)
    {
        if (GameManager.Instance.isPlayerMoving)
        {
            yield break;
        }
        GameManager.Instance.isPlayerMoving = true;
        currentPos++;
        currentPos %= GameBoard.Instance.Tiles_Fat_Race.Count;
        Vector3 nextPos = GameBoard.Instance.Tiles_Fat_Race[0].transform.position;
        nextPos.y = 0.25f;
        while (MoveToNextTiles(nextPos, player)) { yield return null; }
        yield return new WaitForSeconds(.2f);
            
        GameManager.Instance.isPlayerMoving = false;

        // popup panel when player stop moving
    }

    bool MoveToNextTiles(Vector3 nextTiles,Player player)
    {

        return nextTiles != (player.Avatar.transform.position = Vector3.MoveTowards(player.Avatar.transform.position, nextTiles, 10f * Time.deltaTime));
    }

    void PopupPanel(Tile tile)
    {
        // Compare cuurent position to popup panel 
        // Oppotunity, Charity, PayCheck, Offer,DownSize,Doodads
        switch (tile.Type)
        {
            case TileType.Oppotunity:
                UI_Manager ui = GetComponentInChildren<UI_Manager>();
                ui.PopUpDeal_UI();
                break;
            case TileType.Offer:
                //UI_Manager.Instance.PopUpDeal_UI();
                Debug.Log(EvenCard_Data.instance.Markets[Random.Range(0, EvenCard_Data.instance.Markets.Count)].Title);
                break;
            case TileType.Charity:
                //UI_Manager.Instance.PopUpDeal_UI();
                Debug.Log("Charity");
                break;
            case TileType.DownSize:
                //UI_Manager.Instance.PopUpDeal_UI();
                Debug.Log("DownSize");
                break;
            case TileType.Doodads:
                //UI_Manager.Instance.PopUpDeal_UI();
                Debug.Log(EvenCard_Data.instance.Doodads[Random.Range(0, EvenCard_Data.instance.Doodads.Count)].Title);
                break;
            default:
                break;
        }
    }

    private void Paycheck()
    {
        float total_expense = 0;
        float total_income = 0;
        foreach(game_accounts account in player.financial_rp.game_accounts)
        {
            if(account.gameAccount_type == AccountType.Income)
            {
                total_income += account.gameAccount_cost;
            }else if(account.gameAccount_type == AccountType.Expense)
            {
                total_expense += account.gameAccount_cost;
            }
        }
        player.financial_rp.SetCash(player.financial_rp.GetCash() + total_income - total_expense);
    }
}
