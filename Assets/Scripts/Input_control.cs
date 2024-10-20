using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace zhb
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Input_control : MonoBehaviour
    {
        public Vector2 move;
        private Animator animator;
        private Rigidbody2D rd;
        private float moveSpeed = 4f;
        //private float up;
        //private float down;
        //private float left;
        //private float right;

        public Vector2 Move { get => move; }

        private void Start()
        {
            animator = GetComponent<Animator>();
            rd = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            
        }
        private void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
            if (move.x == 0 && move.y == 0)
            {
                animator.SetInteger("isMoving", 0);
            }
            else
            {
                animator.SetInteger("isMoving", 1);
                animator.SetFloat("x", move.x);
                animator.SetFloat("y", move.y);
            }
            rd.velocity = moveSpeed * move;
        }

        
    }

}