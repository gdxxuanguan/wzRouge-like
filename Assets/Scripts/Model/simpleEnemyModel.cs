using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEnemyModel : enemyModel
{
    public simpleEnemyModel()
    {
        MaxHealth = 200;
        CurrentHealth= 200;
        AttackPower = 20;
        Speed = 2f;
        AttackSpeed = 4f;
    }
}
