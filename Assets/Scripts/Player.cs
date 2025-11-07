using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player ST {get; private set;}

    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private bool isJump;
    [SerializeField] private bool isInAir;

    private Rigidbody2D rb;
    private GroundDetection gd;

    private void Awake()
    {
        ST = this;
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
    }

    private void FixedUpdate () {

        direction = new Vector2(x: 0, rb.linearVelocity.y);

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        
        Move(direction);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gd.IsGrounded() && !isJump)
            Jump();
        
        if (isInAir && gd.IsGrounded())
        {
            isJump = false;
            isInAir = false;
        }
    }

    private void Move(Vector2 dir)
    {
        rb.linearVelocity = new Vector2(x: dir.x * speed, rb.linearVelocity.y);
    }

    private void Jump() 
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        isJump = true;
        Invoke(nameof(Onair), 0.1f);
    }

    private void Onair()
    {
        isInAir = true;
    }

}