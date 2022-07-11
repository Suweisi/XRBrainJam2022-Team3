using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGetStartedBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject canvasPhoneUI; 
    public void OnImReadyButtonPress() {
        gameObject.SetActive(false); 
        canvasPhoneUI.SetActive(false); 
        GetComponent<EventTransitioner>().endConditionReached = true; 
    }
}
