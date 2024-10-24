using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class bomb : bullet
    {
        private Animator animator;
        private float explosionRadius = 0.7f; // 爆炸半径
        private float damage = 30; // 伤害值

        public float ExplosionRadius { get => explosionRadius; set => explosionRadius = value; }

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            Destroy(gameObject, 2f);
            Invoke(nameof(explode), 1f);
            
            
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void explode()
        {

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetBool("exploable", true);
           
            // 在炸弹当前位置创建一个圆形，检测在该圆形范围内的所有2D碰撞体
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

            // 遍历所有被击中的对象
            foreach (Collider2D nearbyObject in colliders)
            {
                // 检查该对象是否具有可受到伤害的组件
                Health targetHealth = nearbyObject.GetComponent<Health>();
                if (targetHealth != null)
                {
                    // 对对象施加伤害
                    targetHealth.TakeDamage(damage);
                    Debug.Log("damage");
                }
            }
        }
        // 用于可视化爆炸范围
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red; // 设置 Gizmos 的颜色
            Gizmos.DrawWireSphere(transform.position, explosionRadius); // 绘制爆炸范围的圆形
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            explode();
            CancelInvoke("explode");
        }
    }

}