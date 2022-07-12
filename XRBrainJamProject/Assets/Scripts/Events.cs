using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public List<GameObject> gameObjectEventList = new List<GameObject>(); 

    [System.NonSerialized]
    public int eventCounter = 0; 
    int sizeOfList; 

    void Awake() {
        gameObjectEventList[eventCounter].SetActive(true); 
        sizeOfList = gameObjectEventList.Count; 
    }

    void Update() {
        var currentEvent = gameObjectEventList[eventCounter];  
        var currentEventTransitioner = currentEvent.GetComponent<EventTransitioner>(); 
        if (eventCounter + 1 == sizeOfList) {
            return; 
        }
        if (currentEventTransitioner.endConditionReached) {
            if (gameObjectEventList[eventCounter + 1] != null) {
                var nextEventIndex = eventCounter + 1; 
                gameObjectEventList[nextEventIndex].SetActive(true); 
                eventCounter+=1; 
            }
        }
    }
    
}
