using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb{
    public abstract class bullet : MonoBehaviour
    {
        public float damage; // �˺�ֵ
        public string frendTag;//��Ӫ���
        public float destroyTime;//�೤ʱ�����ʧ

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
