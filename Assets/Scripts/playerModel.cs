using UnityEngine;

namespace zhb
{
    class playerModel
    {
        // ��������
        private float MaxHealth { get;  set; }  // �������ֵ
        private float CurrentHealth { get;  set; }  // ��ǰ����ֵ
        private float MaxMana { get;  set; }  // �������
        private float CurrentMana { get;  set; }  // ��ǰ����
        private float AttackPower { get;  set; }  // ������
        private float CritRate { get;  set; }  // �����ʣ�0.0 ~ 1.0��
        private float Defense { get;  set; }  // ������
        private float CritDamageMultiplier { get;  set; }  // �����˺�����
        private float Speed { get; set; }  // �ٶ�/�ƶ��ٶ�

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