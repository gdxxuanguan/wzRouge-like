using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhb
{
    public class bagModel
    {
        private List<Item> items;
        private int bagSize;
        public bagModel(int size)
        {
            items = new List<Item>();
            bagSize = size;
        }
        public List<Item> getAll()//��ȡ������Ʒ�б�
        {
            return items;
        }
        public bool addItem(Item i)//���������Ʒ���ϲ����½���
        {
            foreach(Item item in items)
            {
                if (item.name == i.name)
                {
                    item.add(i);
                    return true;
                }
            }
            if (items.Count == bagSize)
            {
                return false;
            }
            else
            {
                items.Add(i);
                return true;
            }
        }
        public bool getItem(string name,int num)//���������Ʒ�������Ʒ��Ϊ0ɾ��
        {
            foreach(Item item in items)
            {
                if (item.name == name)
                {
                    if (item.fetch(num))
                    {
                        if (item.Quantity == 0)
                        {
                            items.Remove(item);
                        }
                    }
                }
            }
            return false;
        }
    }
}