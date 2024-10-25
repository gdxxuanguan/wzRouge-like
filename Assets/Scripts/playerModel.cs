using UnityEngine;

namespace zhb
{
    class playerModel
    {
        // 基础属性
        private float MaxHealth { get;  set; }  // 最大生命值
        private float CurrentHealth { get;  set; }  // 当前生命值
        private float MaxMana { get;  set; }  // 最大蓝量
        private float CurrentMana { get;  set; }  // 当前蓝量
        private float AttackPower { get;  set; }  // 攻击力
        private float CritRate { get;  set; }  // 暴击率（0.0 ~ 1.0）
        private float Defense { get;  set; }  // 防御力
        private float CritDamageMultiplier { get;  set; }  // 暴击伤害倍率
        private float Speed { get; set; }  // 速度/移动速度

        private playerView player;
        void PlayerModel(playerView p) {
            player = p;
            MaxHealth = 100f;
            CurrentHealth = 100f;
            MaxMana = 100f;
            CurrentMana = 100f;
            AttackPower = 20f;
            CritRate = 0f;
            Defense = 0;
            CritDamageMultiplier = 2f;
            Speed = 2f;
        }
        
        public void move(Vector2 move)
        {
            player.move(move, Speed);
        }

        public void attacked(float damage)
        {
            CurrentHealth -= damage;
            player.updateHpView(CurrentHealth / MaxHealth);
            if (CurrentHealth <= 0)
            {
                player.die();
            }
        }

        public void healed(float healAmount)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + healAmount, MaxHealth);
            player.updateHpView(CurrentHealth / MaxHealth);
        }
       
        

        

    }
}