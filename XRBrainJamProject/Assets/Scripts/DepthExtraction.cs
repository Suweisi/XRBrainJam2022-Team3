using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro; 

public class DepthExtraction : MonoBehaviour
{
    [SerializeField]
    GameObject arCamera; 
    [SerializeField]
    TMP_Text debugText; 

    AROcclusionManager occlusionManager; 
    

    void Awake() {
        occlusionManager = arCamera.GetComponent<AROcclusionManager>(); 
    }

    void Start() {
        if (occlusionManager.descriptor?.supportsEnvironmentDepthImage == true) {
            debugText.text = "supported";
        } else {
            debugText.text = "not supported"; 
        }
    }
}
