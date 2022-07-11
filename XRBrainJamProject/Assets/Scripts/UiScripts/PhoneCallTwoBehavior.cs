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
    [SerializeField]
    GameObject postAlexCallAudioGameObject; 

    void Awake() {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update() {
        if (!audioSource.isPlaying) {
            //setObject.SetActive(true); 
            gameObject.SetActive(false); 
            postAlexCallAudioGameObject.GetComponent<AudioSource>().Play(); 
            destMan.GetComponent<DestinationManager>().phaseTwoStarted = true; 
            phoneUICanvas.SetActive(false);
        }
    }
}
