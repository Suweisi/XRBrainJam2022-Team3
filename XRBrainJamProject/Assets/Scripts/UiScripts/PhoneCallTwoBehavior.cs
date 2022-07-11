using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallTwoBehavior : MonoBehaviour
{
    AudioSource audioSource; 
    [SerializeField]
    GameObject phoneUICanvas;
    [SerializeField]
    GameObject destMan; 

    void Awake() {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update() {
        if (!audioSource.isPlaying) {
            //setObject.SetActive(true); 
            gameObject.SetActive(false); 
            destMan.GetComponent<DestinationManager>().phaseTwoStarted = true; 
            phoneUICanvas.SetActive(false);
        }
    }
}
