public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers();
}

public interface IObserver
{
    void Update(ISubject subject);
}

public class Enemy : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}

public class Player : IObserver
{
    private Enemy enemy;

    public Player(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.RegisterObserver(this);
    }

    public void Update(ISubject subject)
    {
        if (subject is Enemy enemy)
        {
            if (enemy.Health <= 0)
            {
                // Düşman öldü!
            }
        }
    }
}


// yusufortacdeveloper