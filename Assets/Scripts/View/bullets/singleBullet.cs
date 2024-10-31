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
            GameObject col= collision.gameObject;
            if (col.tag==frendTag || col.tag == "weapon")
            {
                return; //´©¹ý¶ÔÏó
            }
            if(frendTag=="Player"){
               
                if (col.CompareTag("stone"))
                {
                    col.GetComponent<stoneController>().TakeDamage(damage);
                }else if(col.CompareTag("enemy"))
                {
                    col.GetComponent <simpleEnemyController>().TakeDamage(damage);
                }
            }else{
               
                if (col.CompareTag("Player"))
                {
                    col.GetComponent<playerController>().TakeDamage(damage);
                }
            }
            effectFactory.Instance.Geteffect("boomEffect", gameObject.transform.position, Quaternion.identity);
            CancelInvoke(nameof(returnBullet));
            returnBullet();
        }
    }
}