using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{   
    [System.NonSerialized]
    public int numOfObjectsPutAway; 

    [SerializeField]
    GameObject[] soundTriggerObjects; 

    [SerializeField]
    AudioClip[] audioClipList; 

    //dictionary maps the tags of movable objects to the audio clip associated with the object
    Dictionary<GameObject[], AudioClip> tagToAudioDictionary = new Dictionary<GameObject[], AudioClip>(); 

    void Awake() {
        
    }

    void Update() {
        if (numOfObjectsPutAway > 3) {
            GetComponent<EventTransitioner>().endConditionReached = true; 

        }
    }
}
