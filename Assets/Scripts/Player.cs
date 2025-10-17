using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;

    private Rigidbody2D rb;
    private GroundDetection gd;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
    }

    private void Update () {

        direction = new Vector2(x: 0, rb.linearVelocity.y);

        if (Input.GetKey(KeyCode.D))
        {

            direction = Vector2.right;

        }
        else if (Input.GetKey(KeyCode.A))
        {

            direction = Vector2.left;

        }
        if (Input.GetKey(KeyCode.Space) && gd.IsGrounded())
        {
            Jump();
         
        
        }

        Move(direction);
    }

    private void Move(Vector2 dir)
    {
        
         rb.linearVelocity = new Vector2(x: dir.x * speed, rb.linearVelocity.y);

    }

    private void Jump() 
    {

        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

    }

}