using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image greenLine;
    private Health playerHealth;

    private void OnEnable()
    {
        playerHealth = Player.ST.GetComponent<Health>();
        playerHealth.healthChanged += ChangeHp;
        playerHealth.healthDamage += GamageHp;
        playerHealth.isDead += Dead;
    }
    private void ChangeHp()
    {
        Debug.Log("Heal!");
    }

    private void GamageHp()
    {
        Debug.Log("Damage!!");
    }

    private void Dead()
    {
        Debug.Log("You are dead!");
    }


}
