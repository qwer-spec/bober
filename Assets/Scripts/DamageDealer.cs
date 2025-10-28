using UnityEngine;
public enum OtherHealtOwner: byte
{
    Enemy,
    Player
}
public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private OtherHealtOwner otherHealtOwner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(otherHealtOwner.ToString()))
        {
            GameManager.ST.healthContainer[other.gameObject].TakeDamage(damage);
        }
    }

}
