//Activity 4
interface FirstInterface
{
    int math { get; set; }
}

public class Work : FirstInterface
{
    private int nums;

    public int math //properties
    {
        get { return nums; }
        set { nums = value; }
    }

    public delegate void Notify(); //delegate
    public event Notify? ProcessComplete; //event

    public void StartProcess()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"This is the value of nums: '{nums}'.");
        OnProcessComplete();
    }

    protected virtual void OnProcessComplete()
    {
        if (ProcessComplete != null) ProcessComplete.Invoke();
    }
}

public class WorkEvent
{
    public void OnProcessComplete()
    {
        Console.WriteLine("Finished task!");
    }
}



public class IndexTesting
{
    private string[] name = new string[5];

    public string this[int index]
    {
        get { return name[index]; }
        set { name[index] = value; }
    }
}



//Main function
public class Program
{
    static void Main()
    {
        var testWork = new Work();
        testWork.math = 2;
        var testEvent = new WorkEvent();
        testWork.ProcessComplete += testEvent.OnProcessComplete;
        testWork.StartProcess();

        var testIndex = new IndexTesting();
        testIndex[0] = "B";
        testIndex[1] = "Ba";
        testIndex[2] = "Bab";
        testIndex[3] = "Babe";
        testIndex[4] = "Babel";

        Console.Write("Printing values stored in objects used as arrays\n");

        // printing values
        Console.WriteLine("First value = {0}", testIndex[0]);
        Console.WriteLine("Second value = {0}", testIndex[1]);
        Console.WriteLine("Third value = {0}", testIndex[2]);
        Console.WriteLine("Third value = {0}", testIndex[3]);
        Console.WriteLine("Third value = {0}", testIndex[4]);

        Console.ReadKey();
    }
}