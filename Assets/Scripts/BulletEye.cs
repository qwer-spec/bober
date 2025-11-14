using UnityEngine;

public class BulletEye : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Shoot(Transform eye)
    {
        transform.position = eye.position;
        gameObject.SetActive(true);
        _rigidbody2D.AddForce(eye.localScale*speed, ForceMode2D.Impulse);
        Invoke(nameof(Retutn), 1.5f);
    }

    private void Retutn()
    {
        _rigidbody2D.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
