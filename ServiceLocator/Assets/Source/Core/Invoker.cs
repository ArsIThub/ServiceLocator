using UnityEngine;
using Zenject;

public class Invoker : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;

    private PlayerData _playerData;

    private BulletPool _bulletPool;
    private TargetData _targetData;

    [Inject]
    public void Construct(PlayerMovement movement, PlayerShooting shooting, PlayerData playerData, BulletPool bulletPool, TargetData targetData)
    {
        _playerMovement = movement;
        _playerShooting = shooting;
        _playerData = playerData;
        _bulletPool = bulletPool;
        _targetData = targetData;
    }

    public void InvokeMove(Vector2 direction)
    {
        _playerMovement.Move(direction, _playerData.Rb, _playerData.Speed);
    }

    public void InvokeShoot()
    {
        _playerShooting.Shoot(_playerData.ShootPoint, null, _bulletPool, _targetData,
            _playerData.AudioSource, _playerData.ShootClip, _playerData.ShootCooldown);
    }
}
