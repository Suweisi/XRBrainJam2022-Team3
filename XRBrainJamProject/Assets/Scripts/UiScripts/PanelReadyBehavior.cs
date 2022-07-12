using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PanelReadyBehavior : MonoBehaviour
{
    Image image;
    [SerializeField]
    GameObject setObject; 
    [SerializeField]
    GameObject uiMusicObj; 
    [SerializeField]
    GameObject phoneCanvasUI; 
    GameObject alphaContainerPanelReady; 


     void Awake() {
        image = alphaContainerPanelReady.GetComponent<Image>();
    }

    void Start() {
        StartCoroutine(FadeAway()); 
    }

    IEnumerator FadeAway() {
        for (float i = 0; i <= 1; i += Time.deltaTime) {
            image.color = new Color(0, 0, 0, i);
            yield return null; 
        }
        setObject.SetActive(true); 
        phoneCanvasUI.SetActive(false); 
        gameObject.SetActive(false);
        GetComponent<EventTransitioner>().endConditionReached = true; 
        yield return StartCoroutine(FadeToScene()); 
    }

    IEnumerator FadeToScene() {
        for (float i = 1; i >= 0; i -= Time.deltaTime) {
            image.color = new Color(0, 0, 0, i);
            yield return null; 
        }

        Debug.Log("starting set scene - phone finder"); 
        yield return null;
    }


/*
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
*/
}
