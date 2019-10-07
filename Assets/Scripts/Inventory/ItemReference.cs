using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReference : MonoBehaviour {

    public Item[] items;
    public Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();


    public void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            itemDictionary.Add(items[i]._name.ToLower(), items[i]);
        }
    }

    public Item GetItem(string _name)
    {
        Item item = itemDictionary[_name.ToLower()];
        return item;
    }
}
