using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class stoneController : MonoBehaviour
    {
        public float Health;
        public List<string> dropsName;
        private stoneView view;
        private stoneModel model;

        void Start()
        {
            model = new stoneModel(Health, dropsName);
            view = GetComponent<stoneView>();
        }

        public void TakeDamage(float damage)
        {
            model.Attacked(damage);
            if (model.Health == 0)
            {
                view.changeState();
                //爆装备业务逻辑
                drops();
                Destroy(gameObject, 0.5f);
            }
        }

        private void drops()
        {

        }
    }
}
