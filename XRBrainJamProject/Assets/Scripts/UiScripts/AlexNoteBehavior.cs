using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexNoteBehavior : MonoBehaviour
{
    public void PressNote() {
        GetComponent<EventTransitioner>().endConditionReached = true; 
        gameObject.SetActive(false); 
    }
}
