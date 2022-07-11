using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{   
    [System.NonSerialized]
    public int numOfObjectsPutAway; 

    [SerializeField]
    string[] objTags; 

    [SerializeField]
    AudioClip[] audioClips; 
    [SerializeField]
    AudioClip[] negativeAudioClips; 

    [System.NonSerialized]
    public bool phaseTwoStarted; 

    //dictionary maps the tags of movable objects to the audio clip associated with the object
    public Dictionary<string, AudioClip> tagToAudioDictionary = new Dictionary<string, AudioClip>(); 
    public Dictionary<string, AudioClip> negativeTagToAudioDictionary = new Dictionary<string, AudioClip>(); 
    public Dictionary<string, int> voiceLineUsedCountDictionary = new Dictionary<string, int>(); 
    [Header("Phone Events")]
    [SerializeField]
    GameObject phoneCanvasUI; 
    [SerializeField]
    GameObject alexPhoneCall; 
    [SerializeField]
    GameObject phone; 
    [SerializeField]
    GameObject phaseThreeInteractables;

    void Awake() {
        phaseTwoStarted = false; 
        for(int i = 0; i < objTags.Length; i++) {
            tagToAudioDictionary[objTags[i]] = audioClips[i];
            voiceLineUsedCountDictionary[objTags[i]] = 0; 
        }
        for(int i = 0; i < objTags.Length; i++) {
            negativeTagToAudioDictionary[objTags[i]] = negativeAudioClips[i]; 
        }   
    }
    int lastInt; 
    void Update() {

        if (lastInt!=numOfObjectsPutAway) {
            Debug.Log("(from dest manager **) value changed to " + numOfObjectsPutAway); 
        }

        if (!phaseTwoStarted) {
            if (numOfObjectsPutAway == 3) {
                //might not have to set end condition... could keep going after throwing ui on the screen
                GetPhoneCallFromAlex(); 
                // GetComponent<EventTransitioner>().endConditionReached = true; 

            }
        } else {
            phaseThreeInteractables.SetActive(true);
        }

        lastInt = numOfObjectsPutAway; 

        
    }

    void GetPhoneCallFromAlex() {
        phoneCanvasUI.SetActive(true);
        alexPhoneCall.SetActive(true); 
        phone.SetActive(true); 
    }

    public void SetAudioClip(AudioClip audioClip) {
        if (!GetComponent<AudioSource>().isPlaying) {
            Debug.Log("PLAY AUDIO"); 
            GetComponent<AudioSource>().clip = audioClip; 
            GetComponent<AudioSource>().Play(); 
        }
    }
}
