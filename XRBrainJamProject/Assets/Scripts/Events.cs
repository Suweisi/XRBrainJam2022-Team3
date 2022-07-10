using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public List<GameObject> gameObjectEventList = new List<GameObject>(); 

    [System.NonSerialized]
    public int eventCounter = 0; 

    void Update() {
        Debug.Log(eventCounter); 
        var currentEvent = gameObjectEventList[eventCounter]; 
        Debug.Log(currentEvent); 
        var currentEventTransitioner = currentEvent.GetComponent<EventTransitioner>(); 
        Debug.Log(currentEventTransitioner); 
        if (currentEventTransitioner.endConditionReached) {
            gameObjectEventList[eventCounter++].SetActive(true); 
            eventCounter++; 
        }
    }
    
}
