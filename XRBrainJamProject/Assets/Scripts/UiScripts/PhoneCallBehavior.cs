using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallBehavior : MonoBehaviour
{

    [SerializeField]
    GameObject phoneRingingObject; 
    public void PressAnswerButton() {
        GetComponent<EventTransitioner>().endConditionReached = true; 
        phoneRingingObject.SetActive(false);  
        gameObject.SetActive(false); 
    }
}
