using UnityEngine;

public class HealthUIEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer healthBar;
    [SerializeField] private SpriteRenderer greenBar;
    [SerializeField] private Health health;

    private void Start()
    {
        health.healthDamage += TakeGamage;
        healthBar.gameObject.SetActive(false);
    }

    private void TakeGamage()
    {
        healthBar.gameObject.SetActive(true);
        greenBar.transform.localScale = new Vector3((float)health.currentHealth / (float)health.maxHealth, 1, 1);
        CancelInvoke();
        Invoke(nameof(inActive), 5.0f);
    }
    private void inActive()
    {
        healthBar.gameObject.SetActive(false);
    }
}
