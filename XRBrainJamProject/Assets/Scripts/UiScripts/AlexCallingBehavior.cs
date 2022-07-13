using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCallingBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject phoneCallAnsweredTwo; 
    [SerializeField]
    GameObject phoneRingingObj;

    void Awake() {
        phoneRingingObj.SetActive(true); 
        phoneRingingObj.GetComponent<AudioSource>().Play();
    }
    
    public void PickUpAlexCall() {
        phoneRingingObj.SetActive(false);
        gameObject.SetActive(false);
        phoneCallAnsweredTwo.SetActive(true); 
        GetComponent<EventTransitioner>().endConditionReached = true; 
    }
}
