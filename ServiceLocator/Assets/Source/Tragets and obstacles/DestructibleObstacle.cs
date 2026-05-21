using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;

    public void DestroyObstacle()
    {
        destroyedParticles.Play();
        gameObject.SetActive(false);
    }
}