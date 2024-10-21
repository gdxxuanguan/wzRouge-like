using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class enemy : MonoBehaviour
    {
        [SerializeField] protected float HP;
        [SerializeField] protected float speed;
        [SerializeField] protected float attack;
        [SerializeField] protected float attackRange;
        protected Transform playerTransform;
        protected Animator animator;
        protected Rigidbody2D rd;
        protected void Start()
        {
            // 使用标签"Player"找到玩家对象，并获取其Transform组件
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            animator = GetComponent<Animator>();
            rd = GetComponent<Rigidbody2D>();
        }
        protected void track()
        {
            Vector2 oritation = (playerTransform.position-transform.position).normalized;
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            if (distance < attackRange) //不需要移动
            {
                animator.SetBool("isMoving", false);
                rd.velocity = Vector2.zero;
                return;
            }
            //需要移动
            animator.SetFloat("x", oritation.x);
            animator.SetFloat("y", oritation.y);
            animator.SetBool("isMoving", true);
            rd.velocity = speed * oritation;

                 
        }

    }

}