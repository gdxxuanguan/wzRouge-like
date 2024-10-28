using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhb;

namespace zhb
{
    public class  exploableBullet : bullet
    {

        private Animator animator;
        public float influenceRadius; // ��ը�뾶
        
        public float animateTime; //�೤ʱ��󲥷ű�ը����
        
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

            // ��ը����ǰλ�ô���һ��Բ�Σ�����ڸ�Բ�η�Χ�ڵ�����2D��ײ��
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, influenceRadius);

            // �������б����еĶ���
            foreach (Collider2D nearbyObject in colliders)
            {
                // ���ö����Ƿ���п��ܵ��˺������
                Health targetHealth = nearbyObject.GetComponent<Health>();
                if (targetHealth != null)
                {
                    // �Զ���ʩ���˺�
                    targetHealth.TakeDamage(damage);
                    
                }
                playerController player=nearbyObject.GetComponent<playerController>();
                if(player!=null){
                    player.OnPlayerAttacked(damage);
                }         
            }
        }
        // ���ڿ��ӻ���ը��Χ
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red; // ���� Gizmos ����ɫ
            Gizmos.DrawWireSphere(transform.position, influenceRadius); // ���Ʊ�ը��Χ��Բ��
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag==frendTag||collision.gameObject.tag=="weapon")
            {
                return; // ����ը
            }
            explode();
            CancelInvoke("explode");
        }
    }

}