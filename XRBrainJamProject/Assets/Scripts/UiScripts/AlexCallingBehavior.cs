using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCallingBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject phone; 
    [SerializeField]
    GameObject phoneCallAnsweredTwo; 
    
    public void PickUpAlexCall() {
        phone.SetActive(false);
        gameObject.SetActive(false);
        phoneCallAnsweredTwo.SetActive(true); 
    }
}
