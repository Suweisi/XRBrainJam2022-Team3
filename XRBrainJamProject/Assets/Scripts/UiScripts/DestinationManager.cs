using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{   
    [System.NonSerialized]
    public int numOfObjectsPutAway; 

    //dictionary maps the tags of movable objects to the audio clip associated with the object
    Dictionary<string, AudioClip> tagToAudioDictionary = new Dictionary<string, AudioClip>(); 

    void Update() {
        if (numOfObjectsPutAway > 3) {
            GetComponent<EventTransitioner>().endConditionReached = true; 
            
        }
    }
}
