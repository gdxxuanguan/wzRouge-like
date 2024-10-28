using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhb;

namespace zhb
{
    public class  exploableBullet : bullet
    {

        private Animator animator;
        public float influenceRadius; // 爆炸半径
        
        public float animateTime; //多长时间后播放爆炸动画
        
        void OnEnable()
        {
            animator = GetComponent<Animator>();
            Invoke(nameof(returnBullet), destroyTime);
            Invoke(nameof(explode), animateTime);
        }

        void explode()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetBool("exploable", true);

            // 在炸弹当前位置创建一个圆形，检测在该圆形范围内的所有2D碰撞体
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, influenceRadius);

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
                playerController player=nearbyObject.GetComponent<playerController>();
                if(player!=null){
                    player.OnPlayerAttacked(damage);
                }         
            }
        }
        // 用于可视化爆炸范围
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red; // 设置 Gizmos 的颜色
            Gizmos.DrawWireSphere(transform.position, influenceRadius); // 绘制爆炸范围的圆形
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag==frendTag||collision.gameObject.tag=="weapon")
            {
                return; // 不爆炸
            }
            explode();
            CancelInvoke("explode");
        }
    }

}