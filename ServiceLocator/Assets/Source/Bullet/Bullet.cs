using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float obstacleCheckRadius = 10f;
    [SerializeField] private LayerMask obstacleMask;
    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip destroyClip;

    private BulletPool _pool;
    private TargetData _target;

    private float _timer;

    public void Initialize(TargetData target, BulletPool pool)
    {
        _target = target;
        _pool = pool;

        _timer = lifeTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            ReturnToPool();
            return;
        }

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;

        Collider2D obstacle = Physics2D.OverlapCircle(transform.position, obstacleCheckRadius, obstacleMask);

        Vector3 direction;

        if (obstacle == null)
        {
            direction = (_target.transform.position - transform.position).normalized;
        }
        else
        {
            direction = transform.right;
        }

        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DestructibleObstacle obstacle))
        {
            audioSource.PlayOneShot(destroyClip);

            obstacle.DestroyObstacle();

            ReturnToPool();
            return;
        }

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        _pool.Return(this);
    }

    public class Factory : PlaceholderFactory<Bullet> { }
}
