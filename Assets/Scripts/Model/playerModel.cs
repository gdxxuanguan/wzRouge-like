using UnityEngine;

namespace zhb
{
    class playerModel
    {
        public float MaxHealth { get; private set; } = 100f;
        public float CurrentHealth { get; private set; } = 100f;
        public float MaxMana { get; private set; } = 100f;
        public float CurrentMana { get; private set; } = 100f;
        public float AttackPower { get; private set; } = 20f;
        public float CritRate { get; private set; } = 0f;
        public float Defense { get; private set; } = 0;
        public float CritDamageMultiplier { get; private set; } = 2f;
        public float Speed { get; private set; } = 2f;

        

        public void Attacked(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                // Player dies, handle death through the controller
            }
        }

        public void Healed(float healAmount)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + healAmount, MaxHealth);
            // Update view through the controller
        }

        public float getHp(){
            return CurrentHealth/MaxHealth;
        }
    }
}
