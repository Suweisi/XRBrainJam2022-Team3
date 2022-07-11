using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PanelReadyBehavior : MonoBehaviour
{
    Image image;
    Image childImage; 
    float waitTime; 
    float elapsedTime; 
    GameObject childObj; 
    [SerializeField]
    GameObject setObject; 
    [SerializeField]
    GameObject uiMusicObj; 

     void Awake() {
        image = GetComponent<Image>();
        childObj = gameObject.transform.GetChild(0).gameObject;
        childImage = childObj.GetComponent<Image>();
        StartCoroutine(FadeToBlack()); 
    }

    IEnumerator FadeToBlack() {
        for (float i = 1; i >= 0; i -= Time.deltaTime * .5f) {
            image.color = new Color(i, i, i, 1);
            childImage.color = new Color(i, i, i, 1); 
            yield return null; 
        }
        image.color = new Color(0, 0, 0, 1);
        childImage.color = new Color(0, 0, 0, 1); 
        childObj.SetActive(false); 
        //turn off the ui music object here
        uiMusicObj.SetActive(false); 
        setObject.SetActive(true); 
        yield return null; 

        
    }
}
