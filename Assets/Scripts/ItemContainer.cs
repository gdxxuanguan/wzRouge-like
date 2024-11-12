using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhb;

public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    private void OnMouseDown()
    {
        InventoryManager.Instance.Add(thisItem);
        InventoryManager.Instance.onInventoryCallBack();
        Destroy(gameObject);

    }
}
