using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro; 
using UnityEngine.UI; 
using System.Linq; 
using Unity.Collections; 



public class PlaneContainer : MonoBehaviour
{
    Camera arCam; 
    //gonna need 5 planes
    int planeCounter; 
    [SerializeField]
    GameObject arSesssionOrigin; 
    ARPlaneManager aRPlaneManager; 
    ARPlane floorPlane; 
    List<Vector3> cornerLocations = new List<Vector3>(); 
    string directionsText; 
    ARRaycastManager m_RaycastManager; 
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>(); 
    [SerializeField]
    TMP_Text debugText; 
    [SerializeField]
    GameObject mapButton; 
    bool mapButtonActive;  
    [SerializeField]
    GameObject floorPlaneObject; 

    [System.NonSerialized]
    public float yGroundValue; 
    EventTransitioner eventTransitioner; 
    [SerializeField]
    GameObject dragManager; 
    [SerializeField]
    GameObject set; 
    [SerializeField]
    GameObject phoneCanvasUI; 
    [SerializeField]
    bool ifDebug; 

    void TurnOffPlanes() {
        aRPlaneManager.enabled = false; 
        foreach(var p in aRPlaneManager.trackables) {
            p.gameObject.SetActive(false);
        }
    }

    private Dictionary<string, float> boundsDictionary = new Dictionary<string, float>(); 
    
 
    void Awake() {
        aRPlaneManager = arSesssionOrigin.GetComponent<ARPlaneManager>(); 
        m_RaycastManager = arSesssionOrigin.GetComponent<ARRaycastManager>();
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();   
        planeCounter = 0; 
        eventTransitioner = GetComponent<EventTransitioner>(); 
        setInit = false; 
    }

    void Start() {
        Debug.Log(floorPlaneObject); 
    }

    bool setInit; 
    bool dragInit; 
    void Update() { 

        // if (setInit & !dragInit) {
        //     dragManager.SetActive(true); 
        //     dragInit = true; 
        // }
        
        //get ground plane - extend the box collider to be big af
        if (planeCounter == 0 && Input.touchCount > 0) {
            //debugText.text = "select ground plane..."; 
            RaycastHit hit;     
            Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position); 
            if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))  {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.collider.gameObject.GetComponent<ARPlane>() != null) {
                            floorPlane = (hit.collider.gameObject.GetComponent<ARPlane>());  
                            yGroundValue = floorPlane.transform.position.y; 
                            planeCounter++;
                        } 
                    }
                }
            }
        } 
        if (planeCounter == 1) {
                //debugText.text = "step 2"; 
                floorPlaneObject.transform.position = new Vector3(0f, yGroundValue, 0f); 
                floorPlaneObject.gameObject.SetActive(true);
                TurnOffPlanes();
                phoneCanvasUI.SetActive(true); 
                eventTransitioner.endConditionReached = true; 
                //set.SetActive(true);
                setInit = true;  
                planeCounter++; 
            }
        //debugText.text = "floor y val: " + floorPlaneObject.transform.position.y.ToString();  
    }

}
