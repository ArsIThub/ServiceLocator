using UnityEngine;

public class PlayerMovement
{
    public void Move(Vector2 direction, Rigidbody2D rigidbody, float speed)
    {
        rigidbody.linearVelocity = direction.normalized * speed;
    }
}