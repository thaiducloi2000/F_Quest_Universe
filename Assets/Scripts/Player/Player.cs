using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    public string id = "7f1515ce-a0bd-4b95-adf7-98d1243e6117CU";
    public Transform root;
    public Vector3 offset;
    // Add Avatar
    public GameObject Avatar;
    public bool isInFatRace = false;
    public int child_amount = 0;
    //public float cash;
    public UI_Manager UI;
    public Financial financial_rp;
    public Job job;
    public Turn myTurn;

    private void Start()
    {
        //setting camera 
        this.transform.position = Vector3.zero;
        root = GameBoard.Instance.Root.transform;
        offset = new Vector3(-GameBoard.Instance.size * 9f, GameBoard.Instance.size * 8f, 0f);
        //offset = new Vector3(0, 7, -9f);
        Camera.main.transform.position = offset;
        //Camera.main.transform.LookAt(root);

        LoadAllJob();
    }


    void Update()
    {
        // camera alway looking to root of Gameboard
        Camera.main.transform.LookAt(root);
        MoveCameraOnCirle();
        //Camera.main.transform.RotateAround(root.transform.position, Vector3.up, 15f * Time.deltaTime);
        //Camera.main.transform.position = offset;
        // Dress Key R to roll
        if (isInFatRace)
        {
            MoveToFatRace();
        }
        if (Input.GetKeyDown(KeyCode.R) && !GameManager.Instance.isPlayerMoving /*&& GameManager.Instance.isTurn == myTurn*/)
        {
            // Role Dice
            int step = Random.Range(1, 7);
            // Test
            Debug.Log("Dice : " + step);
            // Move
            if(isInFatRace)
            {
                StartCoroutine(this.gameObject.GetComponent<Step>().Move(this, step, GameBoard.Instance.Tiles_Fat_Race));
            }
            else
            {
                StartCoroutine(this.gameObject.GetComponent<Step>().Move(this, step, GameBoard.Instance.Tiles_Rat_Race));
            }
            GameManager.Instance.nextTurn();
        }
    }

    public void SelectJoB()
    {
        UI.PopupJob_UI(EvenCard_Data.instance.Job_List[Random.Range(0, EvenCard_Data.instance.Job_List.Count - 1)]);
    }

    public void AcceptJob()
    {
        this.job = UI.Job_Panel.GetComponent<Job_Panel>().job;
        UI.Job_Panel.SetActive(false);
        ApplyJobToFinancial(this.job);
        UI.Financial_Panel.GetComponent<Financial_Panel_Manager>().Financial(this.financial_rp);
    }

    public void ApplyJobToFinancial(Job job)
    {
        float expense = 0;
        foreach(Game_accounts account in job.Game_accounts)
        {
            if(account.Game_account_type == AccountType.Expense)
            {
                expense += account.Game_account_value;
            }
        }
        this.financial_rp = new Financial(child_amount,this.id,job.Job_card_name,0, expense,job.Game_accounts);

        isInFatRace = financial_rp.GetPassiveIncome();
    }

    public void MoveCameraOnCirle()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                Camera.main.transform.RotateAround(root.transform.position,new Vector3(0f,touch.deltaPosition.x,0f), 100f * Time.deltaTime);
            }
        }
    }

    public void MoveToFatRace()
    {
        this.isInFatRace = true;
        this.gameObject.GetComponent<Step>().currentPos = 0;
        StartCoroutine(this.gameObject.GetComponent<Step>().MoveFatRace(this));
    }

    private void LoadAllJob()
    {
        EvenCard_Data.instance.Job_List = new List<Job>();
        StartCoroutine(EvenCard_Data.instance.helper.Get("JobCards/job-card", (request, process) =>
        {
            List<Job> list = ParseJsonToListJob(request);
            foreach (Job job in list)
            {
                EvenCard_Data.instance.Job_List.Add(job);
            }if(request.downloadProgress == 1)
            {
                SelectJoB();
            }
        }
        ));
    }

    private List<Job> ParseJsonToListJob(UnityWebRequest webRequest)
    {
        List<Job> list = new List<Job>();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                //Debug.Log(webRequest.downloadHandler.text);
                list = JsonConvert.DeserializeObject<List<Job>>(webRequest.downloadHandler.text);
                break;
            default:
                break;
        }
        return list;
    }
}
