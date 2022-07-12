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
    EventTransitioner eventTransitioner; 

    void Awake() {
        image = GetComponent<Image>(); 
        alphaVal = image.color.a; 
        eventTransitioner = GetComponent<EventTransitioner>(); 
        StartCoroutine(AlphaFade()); 
    }

    IEnumerator AlphaFade() {
        for (float i = 1; i >= 0; i -= Time.deltaTime * .5f) {
            image.color = new Color(1, 1, 1, i);
            yield return null; 
        }
        gameObject.SetActive(false); 
        image.color = new Color(1, 1, 1, 0); 
        eventTransitioner.endConditionReached = true; 
        yield return null; 
    }
}
