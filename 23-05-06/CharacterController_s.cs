using UnityEngine;

public class CharacterController_s : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera camera1;
    private Camera camera2;
    private GameObject light1;
    private GameObject light2;
    private bool isFacingRight = true;

    private void Start()
    {
        light1 = GameObject.Find("player_flash_1");
        light2 = GameObject.Find("player_flash_2");
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera1 = Camera.main;
        camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
        camera2.enabled = false;
    }

    private void Update()
    {
        spriteRenderer.sortingLayerName = "Default";
        spriteRenderer.sortingOrder = 100;
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        if (horizontalInput < 0)
        {

            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = true;
            if (isFacingRight)
            {
                isFacingRight = false;
                FlipLights();
            }


        }
        else if (horizontalInput > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = false;
            if (!isFacingRight)
            {
                isFacingRight = true;
                FlipLights();
            }
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            animator.SetBool("isWalk", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            camera1.targetDisplay = 1;
            camera2.targetDisplay = 0;
            camera2.enabled = true;
        }
        else if (Input.GetButtonUp("Fire2"))
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Keyon"))
        {
            Transform enterKeyTransform = GameObject.Find("GameMa").transform.GetChild(0);
            enterKeyTransform.gameObject.SetActive(false);
        }
    }


    private void FlipLights()
    {
        light1.transform.localPosition = new Vector3(-light1.transform.localPosition.x, light1.transform.localPosition.y, light1.transform.localPosition.z);
        light2.transform.localPosition = new Vector3(-light2.transform.localPosition.x, light2.transform.localPosition.y, light2.transform.localPosition.z);
    }
}