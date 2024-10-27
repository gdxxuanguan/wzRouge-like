using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemyView : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rd;
    

    void Start()
    {
        //初始化成员变量
        animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
        
    }
    public void Move(Vector2 move, float moveSpeed)
    {
        if (move == Vector2.zero)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        
        rd.velocity = moveSpeed * move;
    }
    public void attack()
    {
        animator.SetBool("attack", true);
    }
}
