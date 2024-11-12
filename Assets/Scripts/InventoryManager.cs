using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using zhb;

public class InventoryManager : MonoBehaviour
{
    #region singleton
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InventoryManager();
            }
            return _instance;
        }
    }
    #endregion

    public List<Item> itemList;
    public delegate void onInventoryChange();
    public onInventoryChange onInventoryCallBack;

    public void Add(Item item)
    {
        itemList.Add(item);
    }

    public void Remove(Item item)
    {
        itemList.Remove(item);
    }
}
