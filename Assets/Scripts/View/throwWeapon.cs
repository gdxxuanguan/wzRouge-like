using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine; 


namespace zhb
{
    
    public class throwWeapon : Weapon
    {      
        private float shootSpeed = 1f;
        private float bulletSpeed = 8f;
        private float lastShootTime = 0f;
        public string bulletName;
        // Start is called before the first frame update
        void Start()
        {
            //InvokeRepeating("Shoot", shootSpeed, shootSpeed);
            lastShootTime = Time.time - shootSpeed;

        }
       
            
        //}
        private void UpdateShootStatus()
        {
            lastShootTime = Time.time;
        }
        private bool CanShoot()
        { 
            return Time.time - lastShootTime >= shootSpeed;
        }
       
        public override void Shoot(Vector2 mPosition)
        {
            if(CanShoot()){
                UpdateShootStatus();
            }else{
                return;
            }

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // ȷ�� z ��Ϊ 0����Ϊ�� 2D

            Vector3 direction = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Vector3 bulletPosition = transform.position; // ���ɵ�λ�� 
            Quaternion rotation = Quaternion.Euler(0, 0, angle);// ������ת

            var bullet = initPrefab(bulletName,bulletPosition,rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * direction;
            bullet.GetComponent<bullet>().frendTag = transform.parent.tag;//���ӵ������Ƿ��ѷ���λ��tag
            // Debug.Log("shoot!");
        }
    }

}