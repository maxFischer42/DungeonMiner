using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject {

    public string type;
    public string tool;
    public int damage;
    public float knockback;
    public float delay;
}
