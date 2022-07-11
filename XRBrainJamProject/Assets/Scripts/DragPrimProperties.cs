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
        positiveAudioDictionary = destinationManagerObject.GetComponent<DestinationManager>().tagToAudioDictionary;
        tagIntDictionary = destinationManagerObject.GetComponent<DestinationManager>().voiceLineUsedCountDictionary; 
        negativeAudioDictionary = destinationManagerObject.GetComponent<DestinationManager>().negativeTagToAudioDictionary;
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
            Debug.Log(gameObject.name + " draggable distance is true"); 
             
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
                            gameObjTag = gameObject.tag; 
                            moveState = true; 
                        }
                    }
                }
            } else if (moveState && Input.GetTouch(0).phase == TouchPhase.Began) {
                moveState = false; 
            }

        }

        if (moveState) { 
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
            Debug.Log("halloa: " + gameObject.name); 
            MoveObjectWithCam(); 
            
        }
       
       lastFrameBool = draggableStateActivated; 
    }

    void MoveObjectWithCam() {
        gameObject.transform.position = arCamera.transform.position + arCamera.transform.forward * distFromCamera; 
    }


}
