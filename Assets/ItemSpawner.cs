using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    // TODO add thing later to check what kind of tool is being used

    public GameObject itemToSpawn;
    public GameObject remains;

    public bool isCrate; //crate can drop different items
    public GameObject[] crateItems;

    public GameObject falsePick;

    int hardness = 1;

    private void Start()
    {        
        if (this.gameObject.name.ToLower().Contains("iron"))
            hardness = 2;
        if (this.gameObject.name.ToLower().Contains("plat"))
            hardness = 3;
        if (this.gameObject.name.ToLower().Contains("diamond"))
            hardness = 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int b = 0;
        var i = GameObject.Find("GameManager").GetComponent<InventoryManager>().current;
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "PlayerHB")
        {
            if (isCrate)
            {
                GameObject g = Resources.Load("WoodBeak") as GameObject;
                GameObject a = (GameObject)Instantiate(g, transform);
                a.transform.parent = null;
                GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Crate") as AudioClip);
                Destroy(a, 4f);
            }
            else
            {
                if (i.data.tool == "pickaxe")
                {
                    switch (i.data.type)
                    {
                        case "wood":
                            b = 1;
                            break;
                        case "copper":
                            b = 2;
                            break;
                        case "iron":
                            b = 3;
                            break;
                        case "plat":
                            b = 4;
                            break;
                    }
                    if (b >= hardness)
                    {
                        GameObject g = Resources.Load("GolemDeath") as GameObject;
                        GameObject a = (GameObject)Instantiate(g, transform);
                        a.transform.parent = null;
                        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Mine") as AudioClip);
                        Destroy(a, 4f);
                    }
                    else
                    {
                        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/FalsePick") as AudioClip);
                    }
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/FalsePick") as AudioClip);
                    falsePick = Resources.Load("NotCorrect") as GameObject;
                    GameObject a = (GameObject)Instantiate(falsePick, transform);
                    a.transform.parent = null;
                    Destroy(a, 3f);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag == "PlayerHB")
        {
            int b = 0;
            print("get hit");
            //check pickaxe and type
            if(!isCrate)
            {
                falsePick = Resources.Load("NotCorrect") as GameObject;
                var i = GameObject.Find("GameManager").GetComponent<InventoryManager>().current;
                if (i.data.tool == "pickaxe")
                {
                    switch (i.data.type)
                    {
                        case "wood":
                            b = 1;
                            break;
                        case "copper":
                            b = 2;
                            break;
                        case "iron":
                            b = 3;
                            break;
                        case "plat":
                            b = 4;
                            break;
                    }
                    if (b >= hardness)
                    {
                        GameObject item = (GameObject)Instantiate(GetItem(), transform);
                        GameObject remainObj = (GameObject)Instantiate(remains, transform);
                        item.transform.parent = null;
                        remainObj.transform.parent = null;
                        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Pebbles") as AudioClip);
                        Destroy(gameObject);
                    }
                    else
                    {
                        GameObject a = (GameObject)Instantiate(falsePick, transform);
                        a.transform.parent = null;
                        Destroy(a, 3f);
                    }
                }

            } else
            {
                falsePick = Resources.Load("DustWood") as GameObject;
                GameObject item = (GameObject)Instantiate(GetItem(), transform);
                GameObject remainObj = (GameObject)Instantiate(remains, transform);
                item.transform.parent = null;
                remainObj.transform.parent = null;
                GameObject a = (GameObject)Instantiate(falsePick, transform);
                a.transform.parent = null;
                Destroy(a, 3f);
                GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/CrateDust") as AudioClip);
                Destroy(gameObject);
            }
            
        }
    }

    GameObject GetItem()
    {
        if(!isCrate)
        {
            return itemToSpawn;
        }
        else
        {
            int r = Random.Range(0, crateItems.Length);
            return crateItems[r];
        }
    }
}
