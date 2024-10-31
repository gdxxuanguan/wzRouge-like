using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class effectFactory
    {
        private string effectPath = "prefab/effect/";
        private static effectFactory _instance;
        public static effectFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new effectFactory();
                }
                return _instance;
            }
        }
        private effectFactory()
        {

        }

        public GameObject Geteffect(string name, Vector2 position, Quaternion rotation)
        {
            GameObject effect = Resources.Load<GameObject>(effectPath + name);
            effect = GameObject.Instantiate(effect);
            effect.transform.SetPositionAndRotation(position, rotation);
            MonoBehaviour.Destroy(effect, 0.5f);
            return effect;
        }
    }

}