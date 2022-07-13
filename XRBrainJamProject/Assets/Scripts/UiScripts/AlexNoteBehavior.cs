using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexNoteBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject callHerAudio; 

    void Update() {
        if (!GetComponent<AudioSource>().isPlaying) {
            callHerAudio.SetActive(true); 
            GetComponent<EventTransitioner>().endConditionReached = true; 
        }
    }
}
