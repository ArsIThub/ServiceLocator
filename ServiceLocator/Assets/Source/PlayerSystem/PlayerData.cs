using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D Rb { get; private set; }
    [field: SerializeField] public float Speed { get; private set; } = 5f;
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }
    [field: SerializeField] public Transform ShootPoint { get; private set; }
    [field: SerializeField] public float ShootCooldown { get; private set; } = 0.25f;
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public AudioClip ShootClip { get; private set; }
}
