using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] private bool isAlive;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private bool isLookRight = true;
    [SerializeField] private float speed;
    private Vector3 currentTarget;

    private Rigidbody2D _rigidbody2D;
    private Animation _animation;
    private Health _health;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _health = GetComponent<Health>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        isAlive = true;
        currentTarget = startPoint.transform.position;
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (isAlive)
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = (currentTarget == endPoint.position) ? startPoint.position : endPoint.position;
        }

        Flip();
    }

    private void Flip()
    {
        float px = Player.ST.transform.position.x;
        float x = transform.position.x;
        if (px < x && isLookRight || px > x && !isLookRight) 
        { 
            isLookRight = !isLookRight;
            transform.localScale = new Vector3(isLookRight ? 1 : -1, 1, 1);
           
        }
    }

    private IEnumerator Shoot()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(2.0f);
            //_animation.SetTrigger("trAttack");
        }

        yield return null;
    }
}
