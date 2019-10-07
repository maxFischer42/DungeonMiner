using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour {

    public Transform contentHolder;
    public InventoryManager inventory;
    public CraftComplete craftComplete;

    public void Craft()
    {
        if (contentHolder.childCount == 0)
            return;
        List<Item> items = GetItems();
        Item myItem = FindItemCrafted(items);
        for (int i = 0; i < items.Count; i++)
        {
            inventory.RemoveItemFromInventory(items[i]._name.ToLower());
        }
        craftComplete.CompleteCrafting(myItem);
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        int childCount = contentHolder.childCount;
        for (int i = 0; i < childCount; i++)
        {
            items.Add(contentHolder.GetChild(i).GetComponent<ItemSetInfo>().myItem);
            Destroy(contentHolder.GetChild(i).gameObject);
        }
        return items;
    }

   public Item FindItemCrafted(List<Item> items)
   {
        Item myItem = GameObject.Find("GameManager").GetComponent<ItemReference>().GetItem("pebble");
        items.Sort(delegate (Item i1, Item i2) { return i1.name.CompareTo(i2.name); });
        Item[] item_d = GameObject.Find("GameManager").GetComponent<ItemReference>().items;
        for(int i = 0; i < item_d.Length; i++)
        {
            var currentCheck = item_d[i].recipe.items;
            currentCheck.Sort(delegate (Item i1, Item i2) { return i1.name.CompareTo(i2.name); });
            print("currently checking " + item_d[i]._name);
            Debug.Log(items);
            if ( currentCheck.Count == items.Count)
            {
                int counter = 0;
                for (int a = 0; a < currentCheck.Count; a++)
                {
                    if(currentCheck[a] == items[a])
                    {
                        counter++;
                    }
                }
                if(counter == currentCheck.Count)
                {
                    print("matched with " + item_d[i]._name);
                    myItem = item_d[i].recipe.reward;
                }
            }
        }
        return myItem;
   }
    
}

[System.Serializable]
public class RecipeReq
{
    public List<Item> items;
    public Item reward;
}
