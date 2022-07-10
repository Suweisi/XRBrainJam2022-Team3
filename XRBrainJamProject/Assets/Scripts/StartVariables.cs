using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVariables : MonoBehaviour
{
    Camera arCam; 

    public Vector3 startPosition;
    public bool endCondition; 
    EventTransitioner eventTransitioner;  
    void Awake() {
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>(); 
        eventTransitioner = GetComponent<EventTransitioner>(); 
    }

    void Start() {
        eventTransitioner.endConditionReached = true; 
    }
}
