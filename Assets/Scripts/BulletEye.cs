using UnityEngine;

public class BulletEye : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        gameObject.SetActive(false);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Transform eye, bool isRight)
    {
        gameObject.SetActive(true);
        transform.position = eye.position;
        _rigidbody2D.AddForce((isRight? Vector2.right: Vector2.left)*speed, ForceMode2D.Impulse);
        Invoke(nameof(Retutn), 1.5f);
    }

    private void Retutn()
    {
        _rigidbody2D.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
