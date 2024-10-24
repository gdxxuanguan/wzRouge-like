using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace zhb
{
    public class playerHealth : Health
    {
        private Slider slider;
        // Start is called before the first frame update
        void Start()
        {
            slider = GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<Slider>();
            base.Start();
            slider.value = currentHealth / healthLimit;
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            slider.value = currentHealth / healthLimit;
        }
    }

}