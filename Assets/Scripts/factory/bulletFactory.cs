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

        // ���ڴ洢��ͬ������ӵ�Ԥ����
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

        // ÿ���ӵ����͵Ķ����
        private Dictionary<string, List<GameObject>> bulletPools;
        public int poolSize = 20; // ÿ���ӵ��ĳ�ʼ����ش�С

        void Awake()//��ʼ�������Ͷ����
        {
            var bulletPoolParent = new GameObject("bulletPool");
            bulletTypes = new BulletType[types.Length];
            for(int i=0;i<types.Length;i++){
                bulletTypes[i].typeName=types[i];
                bulletTypes[i].bulletPrefab=Resources.Load<GameObject>(prefabPath+types[i]);//��prefab�ļ��м���Ԥ�Ƽ�  
            }
        
            // ��ʼ��������ֵ�
            bulletPools = new Dictionary<string, List<GameObject>>();

            // ����ÿ���ӵ����͵Ķ����
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

        // ��ȡһ��ָ�����͵��ӵ�
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

                // �������û�п��õ��ӵ����򴴽��µ��ӵ�
                GameObject newBullet = GameObject.Instantiate(bulletTypes[GetBulletTypeIndex(typeName)].bulletPrefab, position, rotation);
                bulletPools[typeName].Add(newBullet);
                return newBullet;
            }
            else
            {
                Debug.LogWarning("δ�ҵ�����Ϊ " + typeName + " ���ӵ���");
                return null;
            }
        }
        //�黹�ӵ�����
        public void returnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
        }

        // ��ȡ�ӵ����͵�����������������
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