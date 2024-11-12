using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    [CreateAssetMenu(menuName ="Item")]
    public class Item: ScriptableObject
    {
        [SerializeField] private string itemName;
        private int quantity;
        [SerializeField] private Sprite icon;
        private static string itemPath="item";

        public string ItenName { get => itemName; set => itemName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public Sprite Icon { get => icon; set => icon = value; }
        

        public Item(string s)
        {
            itemName = s;
            icon = Resources.Load<Sprite>(itemPath+name);
        }

        public void add(Item item)
        {
            quantity += item.quantity;
        }

        public bool fetch(int num)
        {
            if (quantity >= num)
            {
                quantity -= num;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}