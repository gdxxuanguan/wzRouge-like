using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using zhb;

public class simpleEnemyController : MonoBehaviour
{
    private enemyModel model;
    private simpleEnemyView view;
    private Transform player;
    private float lastAttack;

    void Start()
    {
        model=new simpleEnemyModel();
        view = GetComponent<simpleEnemyView>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, gameObject.transform.position) < 0.5)
        {
            view.Move(Vector2.zero, 0);
            AttackPlayer();
            return;
        }
        Vector2 direction = (player.position - gameObject.transform.position).normalized;
        view.Move(direction, model.Speed);
    }

    public void TakeDamage(int damage)
    {
         model.Attacked(damage);

    }

    public void AttackPlayer()
    {
        if (Time.time - lastAttack >= model.AttackSpeed)
        {
            lastAttack=Time.time;
            view.attack();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,1f );

            // 遍历所有被击中的对象
            foreach (Collider2D nearbyObject in colliders)
            {
                playerController player = nearbyObject.GetComponent<playerController>();
                if (player != null)
                {
                    player.OnPlayerAttacked(1.0f*model.AttackPower);
                }

            }

        }
        // 这里可以调用其他代码来造成伤害
    }
}
