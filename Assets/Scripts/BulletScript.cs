using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    public AudioClip sound;
    public float speed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void DestroyBullet() { Destroy(gameObject); }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();
        GruntScript grunt = collider.GetComponent<GruntScript>();

        if (john != null) john.Hit();
        if (grunt != null) grunt.Hit();
        DestroyBullet();
    }
}
