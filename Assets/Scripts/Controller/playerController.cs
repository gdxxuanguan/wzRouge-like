using UnityEngine;

namespace zhb
{
    class playerController : MonoBehaviour
    {
        
        private playerView view;
        private playerModel model;
        private Weapon weapon;
        private void Start()
        {
            model = new playerModel();
            view=GetComponent<playerView>();
            view.UpdateHpView(model.getHp());
            weapon=GetComponentInChildren<Weapon>();
        }


        public void move(Vector2 move)
        {
            view.Move(move,model.Speed);
        }

        public void OnPlayerAttacked(float damage)
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

    }
}
