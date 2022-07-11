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
    void Awake() {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit; 
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            if (touch.phase == TouchPhase.Began) {
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject == alexNote) {
                        Debug.Log("got the note");
                        GetComponent<EventTransitioner>().endConditionReached = true; 
                        canvasPhoneUI.SetActive(true); 
                    }
                }
            }
        }
    }
}
