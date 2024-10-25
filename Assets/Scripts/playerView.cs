using UnityEngine.UI;
using UnityEngine;

namespace zhb
{
    class playerView:MonoBehaviour
    {
        public Animator animator;
        //public Transform transform;
        public Rigidbody2D rd;
        public Canvas canvas;
        public Slider slider;
    
        public void move(Vector2 move,float moveSpeed)//½ÇÉ«ÒÆ¶¯
        {
            if (animator.runtimeAnimatorController != null)
            {
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
            }
            rd.velocity = moveSpeed * move;
        }

        public void die()//½ÇÉ«ËÀÍö
        {
            Destroy(gameObject);
        }

        public void updateHpView(float val)
        {
            slider.value = val;
        }


    }
}