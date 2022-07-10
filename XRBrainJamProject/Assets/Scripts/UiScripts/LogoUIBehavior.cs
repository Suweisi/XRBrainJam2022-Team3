using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LogoUIBehavior : MonoBehaviour
{

    Image image;
    float alphaVal;
    [SerializeField] 
    float waitTime; 
    float elapsedTime; 
    string teststring; 

    void Awake() {
        image = GetComponent<Image>(); 
        alphaVal = image.color.a; 
        StartCoroutine(AlphaFade()); 
        teststring = "woo";
    }

    void Update() {
        Debug.Log(teststring);
    }

    IEnumerator AlphaFade() {
        for (float i = 1; i >= 0; i -= Time.deltaTime) {
            image.color = new Color(1, 1, 1, i);
            yield return null; 
        }
        teststring = "yuh"; 

    }
}
