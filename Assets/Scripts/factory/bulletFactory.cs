using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace zhb
{
    public class bulletFactory
    {
        private static bulletFactory _instance;

        public static bulletFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new bulletFactory();
                    
                }
                return _instance;
            }
        }

        private bulletFactory()
        {
            Awake();
        }

        // 用于存储不同种类的子弹预制体
        [System.Serializable]
        public struct BulletType
        {
            public string typeName;
            public GameObject bulletPrefab;
        }
        public string[] types={
            "blackBom","bullet1"
        };
        private string prefabPath="prefab/bullet/";
        public BulletType[] bulletTypes;

        // 每种子弹类型的对象池
        private Dictionary<string, List<GameObject>> bulletPools;
        public int poolSize = 20; // 每种子弹的初始对象池大小

        void Awake()//初始化工厂和对象池
        {
            var bulletPoolParent = new GameObject("bulletPool");
            bulletTypes = new BulletType[types.Length];
            for(int i=0;i<types.Length;i++){
                bulletTypes[i].typeName=types[i];
                bulletTypes[i].bulletPrefab=Resources.Load<GameObject>(prefabPath+types[i]);//从prefab文件夹加载预制件  
            }
        
            // 初始化对象池字典
            bulletPools = new Dictionary<string, List<GameObject>>();

            // 创建每种子弹类型的对象池
            foreach (BulletType bulletType in bulletTypes)
            {
                List<GameObject> pool = new List<GameObject>();
                for (int i = 0; i < poolSize; i++)
                {
                    GameObject bullet = GameObject.Instantiate(bulletType.bulletPrefab);
                    bullet.transform.parent = bulletPoolParent.transform;
                    bullet.SetActive(false);
                    pool.Add(bullet);
                }
                bulletPools[bulletType.typeName] = pool;
            }
        }

        // 获取一个指定类型的子弹
        public GameObject GetBullet(string typeName, Vector2 position, Quaternion rotation)
        {
            if (bulletPools.ContainsKey(typeName))
            {
                foreach (GameObject bullet in bulletPools[typeName])
                {
                    if (!bullet.activeInHierarchy)
                    {
                        bullet.transform.position = position;
                        bullet.transform.rotation = rotation;
                        bullet.SetActive(true);
                        return bullet;
                    }
                }

                // 如果池中没有可用的子弹，则创建新的子弹
                GameObject newBullet = GameObject.Instantiate(bulletTypes[GetBulletTypeIndex(typeName)].bulletPrefab, position, rotation);
                bulletPools[typeName].Add(newBullet);
                return newBullet;
            }
            else
            {
                Debug.LogWarning("未找到类型为 " + typeName + " 的子弹！");
                return null;
            }
        }
        //归还子弹给池
        public void returnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
        }

        // 获取子弹类型的索引（辅助函数）
        private int GetBulletTypeIndex(string typeName)
        {
            for (int i = 0; i < bulletTypes.Length; i++)
            {
                if (bulletTypes[i].typeName == typeName)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}