using UnityEngine;

public class CharacterController_s : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera camera1;
    private Camera camera2;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera1 = Camera.main;
        camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
        camera2.enabled = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = true;
            Transform enterKeyTransform = GameObject.Find("GameMa").transform.GetChild(0);
            enterKeyTransform.gameObject.SetActive(false);
        }
        else if (horizontalInput > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            camera1.targetDisplay = 1;
            camera2.targetDisplay = 0;
            camera2.enabled = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            camera1.targetDisplay = 0;
            camera2.targetDisplay = 1;
            camera2.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Keyon"))
        {
            Transform enterKeyTransform = GameObject.Find("GameMa").transform.GetChild(0);
            enterKeyTransform.gameObject.SetActive(true);
        }
    }
}