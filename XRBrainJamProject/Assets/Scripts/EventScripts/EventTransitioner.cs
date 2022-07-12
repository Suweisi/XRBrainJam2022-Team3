using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransitioner : MonoBehaviour
{
    public bool endConditionReached; 
    public bool onlyConditionIsActive; 
    bool isActive = false; 

    void Update() {
        if (onlyConditionIsActive) { 
            if (gameObject.activeSelf) {
                isActive = true; 
                endConditionReached = true; 
            } 
        }
    }
}
