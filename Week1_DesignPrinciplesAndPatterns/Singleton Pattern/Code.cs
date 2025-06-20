using System;

public class Logger
{
    private static Logger instance = null;
    private static readonly object padlock = new object();

    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    public static Logger Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine("LOG: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing Singleton Logger:");

        Logger logger1 = Logger.Instance;
        logger1.Log("First log message");

        Logger logger2 = Logger.Instance;
        logger2.Log("Second log message");

        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("logger1 and logger2 are the same instance.");
        }
        else
        {
            Console.WriteLine("Different instances detected!");
        }
    }
}
