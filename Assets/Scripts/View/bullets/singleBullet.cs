using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace zhb{
    public class singleBullet : bullet
    {
        void Start(){
            Invoke(nameof(returnBullet), destroyTime);
        }

        void destroy(){
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag==frendTag)
            {
                return; //´©¹ý¶ÔÏó
            }
            if(frendTag=="player"){
                collision.GetComponent<playerController>().OnPlayerAttacked(damage);
            }else{
                // collision.GetComponent<playerController>().OnPlayerAttacked(damage);
            }
            destroy();
        }
    }
}