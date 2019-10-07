using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Item item;
    public GameObject popup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("player"));
        {
            GiveItem();
        }
    }

    void GiveItem()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Item") as AudioClip);
        GameObject.Find("GameManager").GetComponent<InventoryManager>().AddItemToInventory(item._name.ToLower());
        GameObject p = (GameObject)Instantiate(popup, transform);
        p.transform.parent = null;
        p.GetComponent<ItemPopup>().SetInfo(item.icon);
        Destroy(gameObject);
    }
}
