using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCallLastBehavior : MonoBehaviour
{
    void Update() {
        if (!GetComponent<AudioSource>().isPlaying) {
            GetComponent<EventTransitioner>().endConditionReached = true;
            gameObject.SetActive(false); 
        }
    }
}
