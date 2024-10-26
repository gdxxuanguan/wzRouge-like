using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb{
    public abstract class bullet : MonoBehaviour
    {
        public float damage; // 伤害值
        public string frendTag;//阵营标记
        public float destroyTime;//多长时间后消失

        public void init(float d,string tag){
            damage=d;
            frendTag=tag;
        }

        public void returnBullet()
        {
            bulletFactory.Instance.returnBullet(gameObject);
        }

    }
}
