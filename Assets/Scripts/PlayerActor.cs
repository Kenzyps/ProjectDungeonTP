using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerActor : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private Vector2 movement;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    protected int level = 0;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movementation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private void Movementation()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        movement = new Vector2(xMove, yMove);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);

        if (xMove > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (xMove < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
