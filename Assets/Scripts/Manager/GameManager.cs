using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Turn { A,B,C,D}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    public GameObject PlayerPrefabs;

    public List<Player> playerList;
    public bool isPlayerMoving;
    // To Defind Player Turn;
    public Turn isTurn;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        // change to Instantiate to list when moving to multilplayer 
        Instantiate(PlayerPrefabs);
    }

    private void Start()
    {
        this.isTurn = Turn.A;
        playerList = new List<Player>();
        FindAllPlayerInScene();
        MoveToStartPoint();
    }


    public void FindAllPlayerInScene()
    {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player.gameObject.GetComponent<Player>());
        }
    }

    public void MoveToStartPoint()
    {
        foreach(Player player in playerList)
        {
            if(player.gameObject.GetComponent<Player>() != null)
            {
                player.Avatar.transform.localScale *= GameBoard.Instance.size;
                Vector3 pos = new Vector3(GameBoard.Instance.Tiles_Rat_Race[0].transform.position.x,0.25f, GameBoard.Instance.Tiles_Rat_Race[0].transform.position.z);
                player.Avatar.transform.position = pos;
            }
        }
    }

    public void nextTurn()
    {
        // switch turn to next player
        switch (isTurn)
        {
            case Turn.A:
                this.isTurn = Turn.B;
                break;
            case Turn.B:
                this.isTurn = Turn.C;
                break;
            case Turn.C:
                this.isTurn = Turn.D;
                break;
            case Turn.D:
                this.isTurn = Turn.A;
                break;
            default:
                Debug.Log("Invalid Turn");
                break;
        }
    }

}
