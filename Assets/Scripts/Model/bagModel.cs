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
        public List<Item> getAll()//获取背包物品列表
        {
            return items;
        }
        public bool addItem(Item i)//背包添加物品（合并或新建）
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
        public bool getItem(string name,int num)//背包获得物品，如果物品数为0删除
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