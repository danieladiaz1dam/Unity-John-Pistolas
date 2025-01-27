using TMPro;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    private float horizonal = .0f;
    private bool flipped;
    private bool isDied = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private TextMeshProUGUI txtMesh;

    public GameObject bullet;
    public int health = 5;
    public float speed = 1;
    public float jumpForce = 150;

    public AudioClip jumpSound, hurtSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        txtMesh = GetComponent<TextMeshProUGUI>();
        txtMesh.text = "ojavjne";
    }

    void Update()
    {
        horizonal = Input.GetAxisRaw("Horizontal");

        animator.SetBool("isRunning", horizonal != 0);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
            Jump();

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizonal, rb.linearVelocityY);

        if (horizonal < 0)
            flipped = true;
        else if (horizonal > 0)
            flipped = false;

        sprite.flipX = flipped;
    }

    private void Jump()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(jumpSound);
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void Shoot()
    {
        Vector3 direction = flipped ? Vector2.left : Vector2.right;
        GameObject b = Instantiate(bullet, transform.position + direction * 0.15f, Quaternion.identity);
        b.GetComponent<BulletScript>().SetDirection(direction);
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        if (isDied) return;

        health -= 1;

        if (health <= 0)
        {
            isDied = true;
            animator.SetBool("isDied", isDied);
        }
        else
            Camera.main.GetComponent<AudioSource>().PlayOneShot(hurtSound);
    }
}
