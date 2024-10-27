using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyModel
{
    public float MaxHealth;
    public float CurrentHealth;
    public float AttackPower;
    public float Speed;
    public float AttackSpeed;
   
    public void Attacked(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            // enemy dies, handle death through the controller
        }
    }

    public void Healed(float healAmount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + healAmount, MaxHealth);
        // Update view through the controller
    }

    public float getHp()
    {
        return CurrentHealth / MaxHealth;
    }

}
