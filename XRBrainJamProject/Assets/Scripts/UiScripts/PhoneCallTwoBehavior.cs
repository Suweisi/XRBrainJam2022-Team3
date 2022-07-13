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
            phoneUICanvas.SetActive(false);
            postAlexCallAudioGameObject.SetActive(true); 
            //postAlexCallAudioGameObject.GetComponent<AudioSource>().Play(); 
            GetComponent<EventTransitioner>().endConditionReached = true; 
            gameObject.SetActive(false);
        }
    }
}
