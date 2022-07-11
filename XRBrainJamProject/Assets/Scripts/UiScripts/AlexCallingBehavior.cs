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
        phone.GetComponent<AudioSource>().enabled = false; 
        phone.SetActive(false);
        gameObject.SetActive(false);
        phoneCallAnsweredTwo.SetActive(true); 
    }
}
