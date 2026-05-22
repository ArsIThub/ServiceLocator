using UnityEngine;

public class PlayerShooting
{
    private float _lastShootTime;

    public void Shoot(Transform shootPoint, Bullet bulletPrefab, BulletPool pool, Target target, AudioSource audioSource, AudioClip shootClip, float cooldown)
    {
        if (Time.time < _lastShootTime + cooldown)
            return;

        _lastShootTime = Time.time;

        Bullet bullet = pool.Get();

        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = Quaternion.identity;

        bullet.Initialize(target, pool);

        bullet.gameObject.SetActive(true);

        audioSource.PlayOneShot(shootClip);
    }
}