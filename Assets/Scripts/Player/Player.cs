using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public int id;
    public Transform root;
    public Vector3 offset;
    // Add Avatar
    public GameObject Avatar;
    public bool isInFatRace = false;

    public UI_Manager UI;

    public Job job;

    private void Start()
    {
        //setting camera 
        this.transform.position = Vector3.zero;
        root = GameBoard.Instance.Root.transform;
        offset = new Vector3(-GameBoard.Instance.size * 10f, GameBoard.Instance.size * 4f, -1.5f);
        //offset = new Vector3(0, 7, -9f);
        Camera.main.transform.position = offset;
        //Camera.main.transform.LookAt(root);
        SelectJoB();
    }
    void Update()
    {
        // camera alway looking to root of Gameboard
        Camera.main.transform.LookAt(root);
        MoveCameraOnCirle();
        //Camera.main.transform.RotateAround(root.transform.position, Vector3.up, 15f * Time.deltaTime);
        //Camera.main.transform.position = offset;
        // Dress Key R to roll
        if (Input.GetKeyDown(KeyCode.R) && !GameManager.Instance.isPlayerMoving)
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
        }
    }

    public void SelectJoB()
    {
        // waiting for db
        Income inc = new Income("Luong", 4600);
        Expense ex = new Expense("Thue", 910);
        Expense ex5 = new Expense("Tra Lai Vay Mua nha", 700);
        Expense ex1 = new Expense("Tra Tien Vay Dai Hoc", 60);
        Expense ex2 = new Expense("Tra Tien Vay mua xe", 120);
        Expense ex3 = new Expense("Tra tien vay the tin dung", 910);
        Expense ex4 = new Expense("Chi Phi mua sam", 910);
        Expense ex6 = new Expense("Chi Phi Khac", 910);
        Asset asset = new Asset("Tien Mat", 400);
        Liability lia = new Liability("No The Chap", 75000);
        Liability lia1 = new Liability("No Dai Hoc", 12000);
        Liability lia2 = new Liability("No Mua Xe", 6000);
        Liability lia3 = new Liability("No The Tin Dung", 3000);
        Liability lia4 = new Liability("No Mua Tra Gop", 1000);
        // -------------------------------------------
        Job job = new Job("job_01", "CEO", 240);
        job.incomes.Add(inc);
        job.expenses.Add(ex);
        job.expenses.Add(ex5);
        job.expenses.Add(ex1);
        job.expenses.Add(ex2);
        job.expenses.Add(ex3);
        job.expenses.Add(ex4);
        job.expenses.Add(ex6);
        job.assets.Add(asset);
        job.liabilities.Add(lia);
        job.liabilities.Add(lia1);
        job.liabilities.Add(lia2);
        job.liabilities.Add(lia3);
        job.liabilities.Add(lia4);
        UI.PopupJob_UI(job);
    }

    public void AcceptJob()
    {
        this.job = new Job(UI.Job_Panel.GetComponent<Job_Panel>().job);
        UI.AcceptJob();
        Debug.Log(this.job.Job_ID);
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
}
