using System.Data;
using System.Diagnostics;

class Program
{
static void Main (string[] args)
{
    Watch main = new Watch(10000);
    main.TimeReached += huj;
    main.Start();
    main.Stop();
}
private static void huj(object sender, EventArgs e)
    {
        Console.WriteLine(DateTime.Now);
    }
}

class Watch
{
    public delegate void Timereached(object sender, EventArgs e);
    public event Timereached TimeReached;
    private Stopwatch clock;
    private int secs;
    public Watch(int timepassed) 
    {
    clock = new Stopwatch();
    secs = timepassed;
    }
    public void Start() 
    {
    clock.Start();
    Console.WriteLine(DateTime.Now);
        while (clock.ElapsedMilliseconds < secs)
        {
        
        }
        OnTimeReached();
    }
    public void Stop()
    {
    clock.Stop();
    Console.WriteLine(clock);
    }
    protected void OnTimeReached() 
    {
        TimeReached?.Invoke(this, EventArgs.Empty);
    }
}