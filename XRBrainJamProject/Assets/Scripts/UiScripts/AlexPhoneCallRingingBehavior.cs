using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexPhoneCallRingingBehavior : MonoBehaviour
{
    //just turn the ringing off and go to next event after certain amount of timem

    void Update() {
        if (GetComponent<AudioSource>().time > 5f) {
            GetComponent<EventTransitioner>().endConditionReached = true; 
            gameObject.SetActive(false); 
        }
    }
}
