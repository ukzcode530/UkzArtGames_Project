using UnityEngine;

public class Creture_scr : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
    }
}