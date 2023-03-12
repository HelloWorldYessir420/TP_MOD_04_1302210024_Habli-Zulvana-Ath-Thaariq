using System;

public class KodePos
{
    public static string getKodePos(string kelurahan)
    {
        switch (kelurahan)
        {
            case "Batununggal":
                return "40266";
            case "Kujangsari":
                return "40287";
            case "Mengger":
                return "40267";
            case "Wates":
                return "40256";
            case "Cijaura":
                return "40287";
            case "Jatisari":
                return "40286";
            case "Margasari":
                return "40286";
            case "Sekejati":
                return "40286";
            case "Kebonwaru":
                return "40272";
            case "Maleer":
                return "40274";
            case "Samoja":
                return "40273";
            default:
                return "Kode pos tidak ditemukan";
        }
    }
}

public class DoorMachine
{
    public State currentState;

    public DoorMachine()
    {
        currentState = new LockedState(this);
    }

    public void setState(State state)
    {
        currentState = state;
    }

    public void Lock()
    {
        currentState.lockDoor();
    }

public void unlock()
{
    currentState.unlockDoor();
}

public interface State
{
    void lockDoor();
    void unlockDoor();
}

public class LockedState : State
{
    private DoorMachine doorMachine;

    public LockedState(DoorMachine doorMachine)
    {
        this.doorMachine = doorMachine;
    }

    public void lockDoor()
    {
        Console.WriteLine("Pintu sudah terkunci");
    }

    public void unlockDoor()
    {
        doorMachine.setState(new UnlockedState(doorMachine));
        Console.WriteLine("Pintu terbuka");
    }
}

public class UnlockedState : State
{
    private DoorMachine doorMachine;

    public UnlockedState(DoorMachine doorMachine)
    {
        this.doorMachine = doorMachine;
    }

    public void lockDoor()
    {
        doorMachine.setState(new LockedState(doorMachine));
        Console.WriteLine("Pintu terkunci");
    }

    public void unlockDoor()
    {
        Console.WriteLine("Pintu tidak terkunci");
    }
}
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Kode pos Batununggal :" + KodePos.getKodePos("Batununggal"));
        Console.WriteLine("Kode pos Kujangsari :" + KodePos.getKodePos("Kujangsari"));
        Console.WriteLine("Kode pos Mengger :" + KodePos.getKodePos("Mengger"));
        Console.WriteLine("Kode pos Wates :" + KodePos.getKodePos("Wates"));
        Console.WriteLine("Kode pos Cijaura :" + KodePos.getKodePos("Cijaura"));
        Console.WriteLine("Kode pos Jatisari :" + KodePos.getKodePos("Jatisari"));
        Console.WriteLine("Kode pos Margasari :" + KodePos.getKodePos("Margasari"));
        Console.WriteLine("Kode pos Sekejati :" + KodePos.getKodePos("Sekejati"));
        Console.WriteLine("Kode pos Kebonwaru :" + KodePos.getKodePos("Kebonwaru"));
        Console.WriteLine("Kode pos Maleer :" + KodePos.getKodePos("Maleer"));
        Console.WriteLine("Kode pos Samoja :" + KodePos.getKodePos("Samoja"));

        Console.WriteLine();

        DoorMachine doorMachine = new DoorMachine();
        Console.WriteLine("Current State: " + doorMachine.currentState);
        doorMachine.Lock () ;

        Console.WriteLine("Current State: " + doorMachine.currentState);
        doorMachine.unlock();

        Console.WriteLine("Current State: " + doorMachine.currentState);
        doorMachine.unlock();

        Console.WriteLine("Current State: " + doorMachine.currentState);
        doorMachine.Lock () ;
    }
}
