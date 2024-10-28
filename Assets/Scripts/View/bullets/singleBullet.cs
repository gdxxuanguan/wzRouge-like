using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace zhb{
    public class singleBullet : bullet
    {
        void OnEnable()
        {
            Invoke(nameof(returnBullet), destroyTime);
        }

      

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag==frendTag || collision.gameObject.tag == "weapon")
            {
                return; //´©¹ý¶ÔÏó
            }
            if(frendTag=="player"){
                collision.GetComponent<playerController>().OnPlayerAttacked(damage);
            }else{
                // collision.GetComponent<playerController>().OnPlayerAttacked(damage);
            }
            effectFactory.Instance.Geteffect("boomEffect", gameObject.transform.position, Quaternion.identity);
            CancelInvoke(nameof(returnBullet));
            returnBullet();
        }
    }
}