using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class FadeIn : MonoBehaviour
{

    TMP_Text image; 
    void Awake() {
        image = GetComponent<TMP_Text>(); 
        StartCoroutine(AlphaFadeUp()); 
    }
    IEnumerator AlphaFadeUp() {
        for (float i = 0; i <= 1; i += Time.deltaTime * .8f) {
            image.color = new Color(0, 0, 0, i);
            yield return null; 
        }
        image.color = new Color(0, 0, 0, 1);
    }
}
