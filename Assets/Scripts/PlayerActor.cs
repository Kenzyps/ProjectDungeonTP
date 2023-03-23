using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerActor : MonoBehaviour
{
    //movimentacao
    [SerializeField] private float velocity = 5f;
    [SerializeField] private Vector2 movement;
    //animacao
    [SerializeField] private Animator anim;

    //colisao
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    //level
    protected int level = 0;

    //=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }
    //=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=
    private void FixedUpdate()
    {
        Movementation();
        
    }
    //=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=
    private void Movementation() //metodo de movimentacao
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        movement = new Vector2(xMove, yMove);


        //resolucao do problema de velocidade aumentada quando o player se move para uma direção diagonal
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        //aplicando a movimentação
        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);

        // fazendo o player olhar para a direção em que ele está andando e ativando a animação certa de acordo com o seu estado
        if (xMove > 0)
        {
            //transform.localScale = new Vector2(1, 1);
            isRunningState(true);
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if (xMove < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            isRunningState(true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (yMove != 0)
        {
            isRunningState(true);
        }
        else if (xMove == 0)
        {
            isRunningState(false);
        }

    }
    //=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private void isRunningState(bool statecondition)
    {
        anim.SetBool("isRunning", statecondition);
    }
}
