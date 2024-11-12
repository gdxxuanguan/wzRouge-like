
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using zhb;
namespace zhb
{
    public class ItemSlot : MonoBehaviour
    {
        public Item item;
        public Image itemImage;
        public Text itemText;

        public void AddItem(Item newitem)
        {
            item = newitem;
            itemImage.sprite = item.Icon;
            itemText.text = item.ItenName;
        }
        void RemoveItem()
        {

        }
        public void clean()
        {
            item = null;
            itemImage.sprite = null;
            itemText.text = "Empty";
        }
    }

}