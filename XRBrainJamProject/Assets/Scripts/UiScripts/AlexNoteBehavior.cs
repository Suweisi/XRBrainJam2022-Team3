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
            if (!callHerAudio.GetComponent<AudioSource>().isPlaying) {
                gameObject.SetActive(false); 
                GetComponent<EventTransitioner>().endConditionReached = true; 
            }
        }
    }
}
