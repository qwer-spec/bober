using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool isActive = true;

    public void Awake()
    {
        GameManager.ST.healthContainer.Add(gameObject, this);
    }

    public void TakeDamage(int dmg)
    {

        if(!isActive) return;

        currentHealth -= dmg;

        if (currentHealth > 0)
            return;
       
        currentHealth = 0;
        isActive = false;
        Invoke(nameof(Activate), 3.0f);
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
