using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefOneBehavior : MonoBehaviour
{
     public void PressNote() {
        GetComponent<EventTransitioner>().endConditionReached = true; 
        gameObject.SetActive(false); 
    }
}
