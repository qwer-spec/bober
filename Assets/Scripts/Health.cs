using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool isActive = true;

    public void Start()
    {
        GameManager.ST.healthContainer.Add(gameObject, this);
        Resurrection();
    }

    public void Resurrection()
    {
        isActive = true;
        DoHeal(maxHealth);
    }

    public void TakeDamage(int dmg)
    {

        if(!isActive) return;

        currentHealth -= dmg;

        if (currentHealth > 0)
            return;

        CheckIsAlive();
        isActive = false;

        Invoke(nameof(Activate), 3.0f);
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void DoHeal(int dmg)
    {
        currentHealth += dmg;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    private void Activate() 
    {
    
     isActive = true;
    
    }
}
