using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class stoneView : MonoBehaviour
    {
        public Sprite defaultSprite;
        public Sprite destroySprite;
        private SpriteRenderer currentSprite;

        private void Start()
        {
            currentSprite = GetComponent<SpriteRenderer>();
            currentSprite.sprite = defaultSprite;
        }
        public void changeState()
        {
            currentSprite.sprite = destroySprite;
        }
    }
}
