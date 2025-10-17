using UnityEngine;

public class GroundDetection : MonoBehaviour
{

    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float CastDistane;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, CastDistane, groundLayer)) return true;
        return false;
    }







    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * CastDistane, boxSize);
    }


}
