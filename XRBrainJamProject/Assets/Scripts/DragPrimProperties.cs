using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPrimProperties : MonoBehaviour
{   
    Camera arCamera; 
    [System.NonSerialized]
    public bool draggableStateActivated;
    [System.NonSerialized]
    public Renderer rend;

    bool lastFrameBool; 
    [SerializeField]
    Vector3 normalScale; 
    [SerializeField]
    Vector3 moveScale; 
    [SerializeField]
    float distFromCamera; 
    bool moveState; 
    

    void Awake() {
        draggableStateActivated = false; 
        rend = gameObject.GetComponent<Renderer>(); 
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
    }

    void Update() {

        if (lastFrameBool!=draggableStateActivated) {
            if (draggableStateActivated) {
                gameObject.transform.localScale = moveScale; 
            } else {
                gameObject.transform.localScale = normalScale; 
            }
        }


        if (draggableStateActivated && Input.touchCount > 0) {
            RaycastHit hit; 
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (!moveState && Input.GetTouch(0).phase == TouchPhase.Began) {
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject == gameObject) {
                        Debug.Log(hit.collider.gameObject.name); 
                        moveState = true; 
                    }
                }
                moveState = true; 
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
