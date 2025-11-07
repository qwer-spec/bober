using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image greenLine;
    private Health playerHealth;

    private void Awake()
    {
        greenLine = GetComponent<Image>();
    }

    private void Start()
    {
        playerHealth = Player.ST.GetComponent<Health>();
        playerHealth.healthChanged += ChangeHp;
        playerHealth.healthDamage += DamageHp;
        playerHealth.isDead += Dead;
    }
    private void ChangeHp()
    {
        Debug.Log("Heal!");
    }

    private void DamageHp()
    {
        greenLine.fillAmount = (float) playerHealth.currentHealth / (float) playerHealth.maxHealth;
    }

    private void Dead()
    {
        Debug.Log("You are dead!");
    }


}
