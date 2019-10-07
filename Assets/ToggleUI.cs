using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {

    public GameObject RecipeUI;

    public void ToggleRecipe()
    {
        RecipeUI.SetActive(!RecipeUI.activeSelf);
    }
}
