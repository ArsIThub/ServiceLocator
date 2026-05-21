using System.Collections.Generic;


public class BulletPool
{
    private readonly Bullet.Factory _factory;

    private Queue<Bullet> _pool = new Queue<Bullet>();

    public BulletPool(Bullet.Factory factory)
    {
        _factory = factory;
    }

    public Bullet Get()
    {
        if (_pool.Count > 0)
        {
            return _pool.Dequeue();
        }

        return _factory.Create();
    }

    public void Return(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);

        _pool.Enqueue(bullet);
    }
}