using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
