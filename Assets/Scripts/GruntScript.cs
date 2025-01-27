using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class GruntScript : MonoBehaviour
{
    private bool flipped;
    private float distance;
    private float lastShoot;
    private bool isDied = false;
    private SpriteRenderer sprite;
    private Animator animator;
    private GameObject john;

    public GameObject bullet;
    public int health = 5;

    public AudioClip hurtSound, deathSound;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        john = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (john == null) return;

        Vector3 direction = john.transform.position - transform.position;

        if (direction.x < 0)
            flipped = true;
        else if (direction.x > 0)
            flipped = false;

        sprite.flipX = flipped;

        distance = Mathf.Abs(john.transform.position.x - transform.position.x);

        if (!isDied && distance < 1f && Time.time > lastShoot + 1f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = flipped ? Vector2.left : Vector2.right;
        GameObject b = Instantiate(bullet, transform.position + direction * 0.15f, Quaternion.identity);
        b.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        health -= 1;

        if (health <= 0)
        {
            isDied = true;
            animator.SetBool("isDied", isDied);

            Camera.main.GetComponent<AudioSource>().PlayOneShot(deathSound);
        } else
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(hurtSound);
        }
    }
}
