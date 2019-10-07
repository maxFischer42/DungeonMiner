using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class InitializeInventory : MonoBehaviour {

    private InventoryManager inventory;
    public GameObject itemPrefab;
    public Transform itemParent;

    private void Start()
    {
        inventory = GetComponent<InventoryManager>();
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < inventory.items.Count; i++)
        {
            print("creating item " + inventory.items[i]);
            GameObject itemUI = (GameObject)Instantiate(itemPrefab, itemParent);
            itemUI.GetComponent<ItemSetInfo>().SetData(inventory.items[i]);
        }
    }

    public void ResetView()
    {
        print("reset");
        for (int i = 0; i < itemParent.childCount; i++)
        {
            Destroy(itemParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject itemUI = (GameObject)Instantiate(itemPrefab, itemParent);
            itemUI.GetComponent<ItemSetInfo>().SetData(inventory.items[i]);
        }
    }

}
