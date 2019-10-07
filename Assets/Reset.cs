using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Reset : MonoBehaviour {

    public Item defaultItem;
    public Item Df;
    private string inventoryFileName = "inventory.json";
    public GameObject transitionObj;
    public void Trigger()
    {
        defaultItem._name = Df._name;
        defaultItem.icon = null;
        defaultItem.recipe = null;
        defaultItem.data = Df.data;
        PlayerPrefs.SetFloat("v", 0.5f);
        print("save");
        Inventory a = new Inventory();
        a.items = new string[0];
        var data = File.CreateText(inventoryFileName);
        data.WriteLine(JsonUtility.ToJson(a));
        data.Close();
    }

    public void ReturnToMenu()
    {
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene("Surface");
    }
}
