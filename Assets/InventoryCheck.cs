using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCheck : MonoBehaviour {

    private InventoryManager i;

	// Use this for initialization
	void Start () {
        i = GameObject.Find("GameManager").GetComponent<InventoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Inventory Size: " + i.items.Count;
	}
}
