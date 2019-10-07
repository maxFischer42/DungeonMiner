﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {

    public string _name;
    public Sprite icon;
    public RecipeReq recipe;
    public bool Weapon;
    public Weapon data;

}
