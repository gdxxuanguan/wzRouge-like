using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhb;

namespace zhb
{
    public class bullet : MonoBehaviour
    {

        private Animator animator;
        public float influenceRadius; // ��ը�뾶
        public float damage; // �˺�ֵ
        public float animateTime; //�೤ʱ��󲥷ű�ը����
        public float destroyTime;//�೤ʱ�����ʧ
        private string frendTag;

        public float InfluenceRadius { get => influenceRadius; set => influenceRadius = value; }
        public string FrendTag { get => frendTag; set => frendTag = value; }

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            Destroy(gameObject, destroyTime);
            Invoke(nameof(explode), animateTime);
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
                    Debug.Log("damage");
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
            if (collision.gameObject.tag==frendTag)
            {
                return; // ����ը
            }
            explode();
            CancelInvoke("explode");
        }
    }

}