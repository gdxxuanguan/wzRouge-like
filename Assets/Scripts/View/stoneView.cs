using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneView : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite destroySprite;
    private Sprite currentSprite;

    private void Start()
    {
        currentSprite = GetComponent<Sprite>();
        currentSprite = defaultSprite;
    }
    public void changeState()
    {
        currentSprite = destroySprite;
    }
}
