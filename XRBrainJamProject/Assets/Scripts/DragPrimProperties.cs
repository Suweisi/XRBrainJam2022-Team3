using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DragPrimProperties : MonoBehaviour
{   
    Camera arCamera; 
    [System.NonSerialized]
    bool draggableStateActivated = false;
    [System.NonSerialized]
    Renderer rend;
    [SerializeField]
    Material normalMat;
    [SerializeField] 
    Material movingMat; 

    bool lastFrameBool; 
    [SerializeField]
    Vector3 normalScale; 
    [SerializeField]
    Vector3 moveScale; 
    [SerializeField]
    float distFromCamera; 
    bool moveState; 
    [SerializeField]
    TMP_Text debugText; 
    

    void Awake() {
        draggableStateActivated = false; 
        rend = gameObject.GetComponent<Renderer>(); 
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
    }

    void Update() {

        if (lastFrameBool!=draggableStateActivated) {
            if (draggableStateActivated) {
                gameObject.transform.localScale = moveScale; 
                rend.sharedMaterial = movingMat;
            } else {
                gameObject.transform.localScale = normalScale; 
                rend.sharedMaterial = normalMat; 
            }
        }

        if (Vector3.Distance(arCamera.transform.position, gameObject.transform.position) < 1.5) {
            draggableStateActivated = true; 
             
        } else {
            draggableStateActivated = false; 
        }

        if (Input.touchCount > 0) {
            if (draggableStateActivated) {
                RaycastHit hit; 
                Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
                if (!moveState && Input.GetTouch(0).phase == TouchPhase.Began) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.collider.gameObject == gameObject) {
                            debugText.text += (" just hit: " + hit.collider.gameObject.name); 
                            moveState = true; 
                        }
                    }
                }
            } else if (moveState && Input.GetTouch(0).phase == TouchPhase.Began) {
                moveState = false; 
            }

        }

        if (moveState) {
            MoveObjectWithCam(); 
        }
       
       lastFrameBool = draggableStateActivated; 
    }

    void MoveObjectWithCam() {
        gameObject.transform.position = arCamera.transform.position + arCamera.transform.forward * distFromCamera; 
    }


}
