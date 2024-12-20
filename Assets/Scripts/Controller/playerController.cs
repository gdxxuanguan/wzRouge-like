using UnityEngine;

namespace zhb
{
    class playerController : MonoBehaviour
    {
        
        private playerView view;
        private playerModel model;
        private Weapon weapon;
        private Collider2D col;
        private void Start()
        {
            model = new playerModel();
            view=GetComponent<playerView>();
            view.UpdateHpView(model.getHp());
            weapon=GetComponentInChildren<Weapon>();
            col=GetComponentInChildren<Collider2D>();
        }

        public void move(Vector2 move)
        {
            view.Move(move,model.Speed);
        }

        public void TakeDamage(float damage)
        {
            model.Attacked(damage);
            view.UpdateHpView(model.getHp());
            if (model.CurrentHealth <= 0)
                view.Die();
        }

        public void OnPlayerHealed(float healAmount)
        {
            model.Healed(healAmount);
            view.UpdateHpView(model.getHp());
        }

        public void shoot(Vector2 mPosition){
            // Debug.Log("palyercontroller");
            if(weapon==null)return;
            // Debug.Log("haveweapon");
            weapon.Shoot(mPosition);
        }

        public void PickupWeapon()//捡起武器，销毁地上武器并创建武器
        {
            string name = null;
            Collider2D[] objs=new Collider2D[10];
            int len = col.OverlapCollider(new ContactFilter2D().NoFilter(), objs);
            int i = 0;
            for (; i < len; i++)
            {
                if (objs[i].CompareTag("weapon")) break;
            }
            if (i==len) return;
            name = objs[i].name;
            Destroy(objs[i].gameObject);
            GameObject _weapon = weaponFactory.Instance.GetWeapon(name, model.weaponPosition+(Vector2)gameObject.transform.position, Quaternion.identity);
            _weapon.transform.parent = gameObject.transform;
            weapon = GetComponentInChildren<Weapon>();

        }

        


    }
}
