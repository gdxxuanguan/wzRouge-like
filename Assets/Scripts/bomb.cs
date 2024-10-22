using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class bomb : MonoBehaviour
    {
        private Animator animator;
        // 爆炸参数
        public float explosionRadius = 0.1f; // 爆炸半径
        public int damage = 50; // 伤害值
                                // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            Destroy(gameObject, 4f);
            Invoke(nameof(explode), 1f);
            
            Gizmos.color = Color.red;

            // 在炸弹当前位置绘制一个代表爆炸范围的线框圆
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
            
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
                }
            }
        }
    }

}