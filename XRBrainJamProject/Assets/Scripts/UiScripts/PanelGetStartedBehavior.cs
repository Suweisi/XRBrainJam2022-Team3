using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PanelGetStartedBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject panelStartedObject; 
    [SerializeField]
    GameObject canvasPhoneUI; 
    [SerializeField]
    GameObject alphaContainer; 
    EventTransitioner eventTransitioner; 
    float alphaVal;
    Image image; 

    bool startRoutineBool = false; 

    void Awake() {
        image = alphaContainer.GetComponent<Image>(); 
        alphaVal = image.color.a; 
        eventTransitioner = GetComponent<EventTransitioner>(); 
        panelStartedObject.SetActive(true); 
    }

    public void OnImReadyButtonPress() {
        alphaContainer.SetActive(true);
        startRoutineBool = true; 
    }

    void Update() {
        if (startRoutineBool) {
            StartCoroutine(AlphaFadeUp());
        }
    }

    IEnumerator AlphaFadeUp() {
        for (float i = 0; i <= 1; i += Time.deltaTime) {
            image.color = new Color(0, 0, 0, i);
            yield return null; 
        }
        image.color = new Color(0, 0, 0, 1);
        eventTransitioner.endConditionReached = true; 
        canvasPhoneUI.SetActive(false); 
        panelStartedObject.SetActive(false);
        yield return StartCoroutine(FadeToScene());
    }   

    IEnumerator FadeToScene() {
        for (float i = 1; i >= 0; i -= Time.deltaTime) {
            image.color = new Color(0, 0, 0, i);
            yield return null; 
        }
        startRoutineBool = false;
        yield return null;
    }
}