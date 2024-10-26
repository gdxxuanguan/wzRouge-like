using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

namespace zhb
{
    class playerView : MonoBehaviour
    {
        private Animator animator;
        private Rigidbody2D rd;
        private Slider slider;

        void Start(){
            //初始化成员变量
            animator=GetComponent<Animator>();
            rd=GetComponent<Rigidbody2D>();
            slider=GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<Slider>();
        }
        public void Move(Vector2 move, float moveSpeed)
        {
            animator.SetInteger("isMoving", move != Vector2.zero ? 1 : 0);
            if (move != Vector2.zero)
            {
                animator.SetFloat("x", move.x);
                animator.SetFloat("y", move.y);
            }
            rd.velocity = moveSpeed * move;
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void UpdateHpView(float val)
        {
            slider.value = val;
        }
    }
}
