using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSetInfo : MonoBehaviour {

    public Text _name;
    public Image _icon;
    public Item myItem;

    public void SetData(string name)
    {
        Item me = GameObject.Find("GameManager").GetComponent<ItemReference>().GetItem(name);
        myItem = me;
        _name.text = me._name;
        _icon.sprite = me.icon;
    }
}
