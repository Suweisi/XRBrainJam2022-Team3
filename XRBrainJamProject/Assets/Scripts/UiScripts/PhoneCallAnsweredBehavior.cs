using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallAnsweredBehavior : MonoBehaviour
{
    AudioSource audioSource; 
    [SerializeField]
    GameObject phoneUICanvas; 
    void Awake () {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update() {
        if (!audioSource.isPlaying) {
            GetComponent<EventTransitioner>().endConditionReached = true; 
            gameObject.SetActive(false); 
            phoneUICanvas.SetActive(false); 
        }
    }
}
