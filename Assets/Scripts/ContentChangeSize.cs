using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentChangeSize : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        RectTransform rect = GetComponent<RectTransform>();
        int childCount = transform.childCount;
        rect.sizeDelta = new Vector2(0, 100 * childCount);
	}
}
