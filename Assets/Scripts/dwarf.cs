using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class dwarf : enemy
    {
        [SerializeField] private GameObject bombPrefab;
        private float throwSpeed = 5f;
        private float attackSpeed = 3f;
        private bool isAttacking = false;
        // Start is called before the first frame update
        new void Start()
        {
            base.Start();
            HP = 100f;
            speed = 2f;
            attack = 10f;
            attackRange = 3f;
           
        }

        // Update is called once per frame
        void Update()
        {
            base.track();
        }
        public override void attackMode()
        {
            if (!isAttacking)
            {
                InvokeRepeating("attackPlayer", 0.5f, attackSpeed);
                isAttacking = true;
            }
        }

        public override void escAttackMode()
        {
            if (isAttacking)
            {
                CancelInvoke("attackPlayer");
                isAttacking = false;
            }
        }
        private void attackPlayer()
        {
            if (playerTransform == null)
            {
                escAttackMode();
                return;
            }
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            var bomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            bomb.GetComponent<bullet>().frendTag = transform.tag;//给子弹打上是否友方单位的tag
            bomb.GetComponent<Rigidbody2D>().velocity = throwSpeed * direction;
            
        }
      
    }
}