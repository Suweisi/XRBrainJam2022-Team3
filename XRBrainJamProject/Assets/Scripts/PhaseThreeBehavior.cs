using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseThreeBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject alexNote; 
    Camera arCamera; 
    [SerializeField]
    GameObject canvasPhoneUI; 
    [SerializeField]
    GameObject arStuff; 
    void Awake() {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
        Debug.Log("STARTED: " + gameObject.name + " phase three baby");
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit; 
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            if (touch.phase == TouchPhase.Began) {
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log(hit.collider.gameObject.name); 
                    if (hit.collider.gameObject == alexNote) {
                        GetComponent<EventTransitioner>().endConditionReached = true; 
                        arStuff.SetActive(false); 
                        canvasPhoneUI.SetActive(true); 
                    }
                }
            }
        }
    }
}
