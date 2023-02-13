using System.Collections.Generic;


public class Job
{
    private string job_ID;
    private string job_Name;
    private float child_expense;
    public List<Income> incomes;
    public List<Expense> expenses;
    public List<Asset> assets;
    public List<Liability> liabilities;

    public Job(string job_ID, string job_Name, float child_expense)
    {
        this.incomes = new List<Income>();
        this.expenses = new List<Expense>();
        this.assets = new List<Asset>();
        this.liabilities = new List<Liability>();
        this.job_ID = job_ID;
        this.job_Name = job_Name;
        this.child_expense = child_expense;
    }

    public Job(Job job)
    {
        this.incomes = job.incomes;
        this.expenses = job.expenses;
        this.assets = job.assets;
        this.liabilities = job.liabilities;
        this.job_ID = job.job_ID;
        this.job_Name = job.job_Name;
        this.child_expense = job.child_expense;
    }

    public string Job_ID { get => job_ID; set => job_ID = value; }
    public string Job_Name { get => job_Name; set => job_Name = value; }

    public float Child_expense { get => child_expense; set => child_expense = value; }
}
