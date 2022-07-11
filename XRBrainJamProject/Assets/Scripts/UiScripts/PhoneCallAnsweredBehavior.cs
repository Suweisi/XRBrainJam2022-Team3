using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallAnsweredBehavior : MonoBehaviour
{
    AudioSource audioSource; 
    [SerializeField]
    GameObject phoneUICanvas; 
    [SerializeField]
    GameObject setObject; 
    void Awake () {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update() {
        if (!audioSource.isPlaying) {
            GetComponent<EventTransitioner>().endConditionReached = true; 
            //setObject.SetActive(true); 
            gameObject.SetActive(false); 
            phoneUICanvas.SetActive(false);
        }
    }
}
