using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action healthChanged;
    public event Action isDead;
    public event Action healthDamage;


    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
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

        CheckIsAlive();
        isActive = false;

        Invoke(nameof(Activate), 1.0f);

        healthDamage?.Invoke();
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {  
           isDead?.Invoke();
           Destroy(gameObject);
        }
           
    }

    public void DoHeal(int dmg)
    {
        currentHealth += dmg;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthChanged?.Invoke();
    }

    private void Activate() 
    {
    
     isActive = true;
    
    }
}
