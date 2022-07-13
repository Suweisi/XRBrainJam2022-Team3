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
    
    string gameObjTag; 
    [SerializeField]
    GameObject destinationManagerObject;
    Dictionary<string, AudioClip> positiveAudioDictionary = new Dictionary<string, AudioClip>(); 
    Dictionary<string, AudioClip> negativeAudioDictionary = new Dictionary<string, AudioClip>(); 
    Dictionary<string, int> tagIntDictionary = new Dictionary<string, int>(); 

    void Awake() {
        draggableStateActivated = false; 
        rend = gameObject.GetComponent<Renderer>(); 
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        destinationManagerObject = GameObject.FindGameObjectWithTag("posdes"); 
        //gameObject.transform.localScale = normalScale; 
        positiveAudioDictionary = destinationManagerObject.GetComponent<DestinationManager>().tagToAudioDictionary;
        tagIntDictionary = destinationManagerObject.GetComponent<DestinationManager>().voiceLineUsedCountDictionary; 
        negativeAudioDictionary = destinationManagerObject.GetComponent<DestinationManager>().negativeTagToAudioDictionary;
    }

    void Update() {

        if (lastFrameBool!=draggableStateActivated) {
            if (draggableStateActivated) {
                Debug.Log("activated!"); 
                //gameObject.transform.localScale = moveScale; 
                rend.sharedMaterial = movingMat; 
            } else {
                //gameObject.transform.localScale = normalScale; 
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
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    if (!moveState) {
                        if (Physics.Raycast(ray, out hit)) {
                            if (hit.collider.gameObject == gameObject) {
                                gameObjTag = gameObject.tag; 
                                moveState = true; 
                            }
                        }
                    } else {
                        moveState = false;
                    }
                }
            }

        }

        if (moveState) { 
            gameObject.GetComponent<Collider>().enabled = false; 
            // if (destManager.voiceLineUsedCountDictionary[gameObjTag] == 0) {
            //     AudioClip audioClip = destManager.tagToAudioDictionary[gameObjTag]; 
            // }   
            if (destinationManagerObject.GetComponent<DestinationManager>().phaseTwoStarted) {
                if (tagIntDictionary[gameObjTag] == 0 || tagIntDictionary[gameObjTag] == 1) {
                    destinationManagerObject.GetComponent<DestinationManager>().SetAudioClip(negativeAudioDictionary[gameObjTag]);
                    tagIntDictionary[gameObjTag] += 1;
                }
            } else { 
                if (tagIntDictionary[gameObjTag] == 0) {
                    destinationManagerObject.GetComponent<DestinationManager>().SetAudioClip(positiveAudioDictionary[gameObjTag]);
                    tagIntDictionary[gameObjTag] += 1;  
                }
            }
            MoveObjectWithCam(); 
        } else {
            gameObject.GetComponent<Collider>().enabled = true;
        }
       
       lastFrameBool = draggableStateActivated; 
    }

    void MoveObjectWithCam() {
        gameObject.transform.position = arCamera.transform.position + arCamera.transform.forward * distFromCamera; 
    }


}
