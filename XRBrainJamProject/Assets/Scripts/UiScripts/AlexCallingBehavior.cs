using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCallingBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject phoneCallAnsweredTwo; 
    [SerializeField]
    GameObject phoneRingingObj;
    
    public void PickUpAlexCall() {
        phoneRingingObj.SetActive(false);
        gameObject.SetActive(false);
        phoneCallAnsweredTwo.SetActive(true); 
    }
}
