using UnityEngine;

public class Player : MonoBehaviour
{

    //[Header("estadisticas")]

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    //[Header("referencias")]

    public bool isGrounded = false;

    public Rigidbody2D rb;
    public Animator bodyAnim; 


    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        bodyAnim.SetBool("grounded", true);
    }

    void Update()
    {

        Movement();
        Jump();
    }
    void Movement()
    {
        float moveHorizontal = 0f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Si la flecha derecha está presionada,
            // el personaje se moverá hacia la izquierda (negativo en el eje X).
            moveHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Si la flecha izquierda está presionada,
            // el personaje se moverá hacia la derecha (positivo en el eje X).
            moveHorizontal = 1f;
        }

        bodyAnim.SetFloat("speed", Mathf.Abs(moveHorizontal) * moveSpeed);
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);


    }
    void Jump()
    {
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                bodyAnim.SetBool("grounded", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            bodyAnim.SetBool("grounded", true);
        }
    }
}
