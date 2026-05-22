using UnityEngine;
using Zenject;

public class Target : MonoBehaviour
{
    private PlayerData _playerData;

    [Inject]
    public void Construct(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.y = _playerData.transform.position.y;
        transform.position = position;
    }
}
