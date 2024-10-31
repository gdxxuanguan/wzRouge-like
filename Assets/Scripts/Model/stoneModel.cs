using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class stoneModel
    {
        public float Health;
        public List<string> dropsName;

        public stoneModel(float health, List<string> drops)
        {
            Health = health;
            dropsName = drops;
        }

        public void Attacked(float damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

    }
}
