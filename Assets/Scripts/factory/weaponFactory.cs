using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

namespace zhb
{
    public class weaponFactory
    {
        private string weaponPath = "prefab/weapon/";
        private static weaponFactory _instance;
        public static weaponFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new weaponFactory();
                }
                return _instance;
            }
        }
        private weaponFactory()
        {
            
        }

        public GameObject GetWeapon(string name,Vector2 position, Quaternion rotation)
        {
            GameObject weapon = Resources.Load<GameObject>(weaponPath+name);
            GameObject.Instantiate(weapon);
            weapon.transform.position = position;
            weapon.transform.rotation = rotation;
            return weapon;
        }
    }
}
