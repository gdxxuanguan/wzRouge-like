using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class bomb : MonoBehaviour
    {
        private Animator animator;
        // ��ը����
        public float explosionRadius = 0.1f; // ��ը�뾶
        public int damage = 50; // �˺�ֵ
                                // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            Destroy(gameObject, 4f);
            Invoke(nameof(explode), 1f);
            
            Gizmos.color = Color.red;

            // ��ը����ǰλ�û���һ������ը��Χ���߿�Բ
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

            // ��ը����ǰλ�ô���һ��Բ�Σ�����ڸ�Բ�η�Χ�ڵ�����2D��ײ��
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

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
            }
        }
    }

}