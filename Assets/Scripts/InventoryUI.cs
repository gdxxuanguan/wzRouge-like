using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhb;
namespace zhb { 
    public class InventoryUI : MonoBehaviour
    {
        public ItemSlot[] itemsSlots;
        public Transform inventoryParent;

        void Start()
        {
            InventoryManager.Instance.onInventoryCallBack += updateUI;
            itemsSlots = inventoryParent.GetComponentsInChildren<ItemSlot>();
        }
        public void updateUI()
        {
            for (int i = 0; i < itemsSlots.Length; i++)
            {
                if (i < InventoryManager.Instance.itemList.Count)
                {
                    itemsSlots[i].AddItem(InventoryManager.Instance.itemList[i]);
                }
                else
                {
                    itemsSlots[i].clean();
                }
            }
        }
    }
}        
