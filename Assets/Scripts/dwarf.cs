using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class dwarf : enemy
    {
        
        // Start is called before the first frame update
        new void Start()
        {
            base.Start();
            HP = 100f;
            speed = 2f;
            attack = 10f;
            attackRange = 3f;

        }

        // Update is called once per frame
        void Update()
        {
            base.track();
        }
    }
}