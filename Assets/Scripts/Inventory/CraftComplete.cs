using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftComplete : MonoBehaviour {

    public GameObject craftingUI;
    public GameObject popupUI;
    public Text text;
    public GameObject equip;
    public GameObject recycle;
    public GameObject addItem;
    public InventoryManager inventory;
    public InitializeInventory init;
    public Item equipped;
    private Item current;

    public void CompleteCrafting(Item item)
    {
        current = item;
        if(item._name == "Pebble" || !item.Weapon)
        {
            equip.SetActive(false);
            if(item._name != "Pebble")
            {
                recycle.SetActive(false);
                addItem.SetActive(true);
            }
        }
        else
        {
            equip.SetActive(true);
        }
        craftingUI.SetActive(false);
        popupUI.SetActive(true);
        text.text = "You have successfully crafted " + item._name + "!";
    }

    public void EquipItem()
    {
        equipped._name = current._name;
        equipped.icon = current.icon;
        equipped.recipe = current.recipe;
        equipped.Weapon = current.Weapon;
        equipped.data = current.data;
        ResetParams();
    }

    public void AddItemToInventory()
    {
        inventory.AddItemToInventory(current._name);
        ResetParams();
    }

    public void Recycle()
    {
        inventory.AddItemToInventory("Pebble");
        ResetParams();
    }

    void ResetParams()
    {
        init.ResetView();
        current = null;
        recycle.SetActive(true);
        addItem.SetActive(false);
        equip.SetActive(true);
        craftingUI.SetActive(true);
        popupUI.SetActive(false);
    }
}
