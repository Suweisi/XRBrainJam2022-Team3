using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVariables : MonoBehaviour
{
    Camera arCam; 

    public Vector3 startPosition;
    public bool endCondition;  
    void Awake() {
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>(); 
    }

    void Start() {
        startPosition = arCam.transform.position;
        endCondition = true; 
    }
}
