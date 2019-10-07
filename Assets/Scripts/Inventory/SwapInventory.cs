using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapInventory : MonoBehaviour {

    public bool isInInventory = true;
    private string inventoryName = "InventoryContent";
    private string craftingName = "CraftingContent";

    private Transform inventoryTransform;
    private Transform craftingTransform;

    private void Start()
    {
        inventoryTransform = GameObject.Find(inventoryName).transform;
        craftingTransform = GameObject.Find(craftingName).transform;
    }

    public void ClickItem()
    {
        transform.parent = null;
        switch(isInInventory)
        {
            case true:
                transform.parent = craftingTransform;
                break;
            case false:
                transform.parent = inventoryTransform;
                break;
        }
        isInInventory = !isInInventory;
    }
}
