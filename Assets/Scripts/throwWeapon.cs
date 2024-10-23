using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine; 


namespace zhb
{
    [RequireComponent(typeof(Input_control))]
    public class throwWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        
        private float shootSpeed = 1f;
        private float bulletSpeed = 8f;
        private float lastShootTime = 0f;
        // Start is called before the first frame update
        void Start()
        {
            //InvokeRepeating("Shoot", shootSpeed, shootSpeed);
            lastShootTime = Time.time - shootSpeed;

        }
        //private void FixedUpdate()
        //{
        //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mousePosition.z = 0; // ȷ�� z ��Ϊ 0����Ϊ�� 2D
            
        //}
        private void UpdateShootStatus()
        {
            lastShootTime = Time.time;
        }
        private bool CanShoot()
        {
            if (Input_control.inputactions.Gameplay.Fire.IsPressed())
            {
                return Time.time - lastShootTime >= shootSpeed;
            }
            return false;
            //if (Time.time - lastShootTime >= shootSpeed)
            //{
            //    print("can shoot");
            //}
            //return Time.time - lastShootTime >= shootSpeed;
        }
        private void FixedUpdate()
        {
            if (CanShoot())
            {
                Shoot();
                UpdateShootStatus();
            }
        }
        void Shoot()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // ȷ�� z ��Ϊ 0����Ϊ�� 2D

            Vector3 direction = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Vector3 bulletPosition = transform.position; // ���ɵ�λ��  
            Quaternion rotation = Quaternion.Euler(0, 0, angle);// ������ת

            var bullet = Instantiate(bulletPrefab, bulletPosition, rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * direction;
            bullet.GetComponent<bullet>().FrendTag = transform.parent.tag;//���ӵ������Ƿ��ѷ���λ��tag
            print("shoot!");
        }
    }

}