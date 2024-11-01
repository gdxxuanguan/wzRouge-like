using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class bagController : MonoBehaviour
    {
        private bagModel model;
        private bagView view;
        private int size = 20;
        void Start()
        {
            model = new bagModel(size);
            view = GetComponent<bagView>();
        }

        
    }
}
