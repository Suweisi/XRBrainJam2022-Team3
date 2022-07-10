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
    }

    void Update() {
        
    }

    IEnumerator AlphaFade() {
        for (float i = 1; i >= 0; i -= Time.deltaTime * .5f) {
            image.color = new Color(1, 1, 1, i);
            yield return null; 
        }
        gameObject.SetActive(false); 
        image.color = new Color(1, 1, 1, 0); 
        yield return null; 
    }
}
