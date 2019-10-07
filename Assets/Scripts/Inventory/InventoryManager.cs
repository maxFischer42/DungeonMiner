using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private string inventoryFileName = "inventory.json";
    public List<string> items = new List<string>();

    public Item current;
    public Item Df;

    public void Start()
    {
        if (File.Exists(inventoryFileName))
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    private void Update()
    {
        if(GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("v");
        }
    }

    public void Save()
    {
        print("save");
        Inventory a = new Inventory();
        a.items = items.ToArray();
        var data = File.CreateText(inventoryFileName);
        data.WriteLine(JsonUtility.ToJson(a));
        data.Close();
    }

    public void Load()
    {
        print("load");
        string dataAsJson = File.ReadAllText(inventoryFileName);
        Inventory inventory = JsonUtility.FromJson<Inventory>(dataAsJson);
        items = inventory.items.ToList<string>();
    }

    public void Reset()
    {
        current._name = Df._name;
        current.icon = null;
        current.recipe = null;
        current.data = Df.data;

        print("save");
        Inventory a = new Inventory();
        a.items = new string[0];
        var data = File.CreateText(inventoryFileName);
        data.WriteLine(JsonUtility.ToJson(a));
        data.Close();
    }

    public void AddItemToInventory(string itemName)
    {
        items.Add(itemName.ToLower());
        Save();
    }

    public void RemoveItemFromInventory(string itemName)
    {
        int i = 0;
        for(int a = 0; a < items.Count; a++)
        {
            if (items[a] == itemName.ToLower())
            {
                i = a;
                break;
            }
        }
        items.RemoveAt(i);
        Save();
    }

}
