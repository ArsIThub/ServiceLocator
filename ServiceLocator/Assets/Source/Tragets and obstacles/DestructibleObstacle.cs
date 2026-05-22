using UnityEngine;

public class DestructibleObstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyedParticles;

    public void DestroyObstacle()
    {
        destroyedParticles.Play();
        destroyedParticles.transform.SetParent(null);

        gameObject.SetActive(false);
    }
}