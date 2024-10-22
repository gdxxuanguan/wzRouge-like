using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class Health : MonoBehaviour
    {
        public float currentHealth;
        public float healthLimit = 100f;
        private void Start()
        {
            currentHealth = healthLimit;
        }


        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Debug.Log(gameObject.name + " died!");
            Destroy(gameObject);
        }
    }
}