using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

namespace zhb
{
    public class enemyFactory
    {
        private string enemyPath = "prefab/enemy/";
        private static enemyFactory _instance;
        public static enemyFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new enemyFactory();
                }
                return _instance;
            }
        }
        private enemyFactory()
        {

        }

        public GameObject GetEnemy(string name, Vector2 position, Quaternion rotation)
        {
            GameObject enemy = Resources.Load<GameObject>(enemyPath + name);
            GameObject.Instantiate(enemy);
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            return enemy;
        }
    }
}
