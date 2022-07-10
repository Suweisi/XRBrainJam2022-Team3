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

    //for testing -> this stuff will move into event system later
    [SerializeField]
    GameObject prim1;

    [System.NonSerialized]
    public float yGroundValue; 
    [System.NonSerialized]
    public bool planeSet; 

    void SetObjectsActive() {
        prim1.GetComponent<Rigidbody>().useGravity = true; 
        prim1.GetComponent<Rigidbody>().detectCollisions = true; 
    }

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
        boundsCreated = false;
        prim1.GetComponent<Rigidbody>().detectCollisions = true;  
    }

    void Start() {
        Debug.Log(floorPlaneObject); 
    }

    void Update() { 
        
        //get ground plane - extend the box collider to be big af
        if (planeCounter == 0 && Input.touchCount > 0) {
            debugText.text = "select ground plane..."; 
            RaycastHit hit;     
            Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position); 
            if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))  {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.collider.gameObject.GetComponent<ARPlane>() != null) {
                            floorPlane = (hit.collider.gameObject.GetComponent<ARPlane>());  
                            yGroundValue = floorPlane.transform.position.y; 
                            planeSet = true; 
                            planeCounter++;
                        } 
                    }
                }
            }

        } 

        if (planeCounter == 1) {
                debugText.text = "step 2"; 
                floorPlaneObject.transform.position = new Vector3(0f, yGroundValue, 0f); 
                floorPlaneObject.gameObject.SetActive(true);
                SetObjectsActive(); 
                TurnOffPlanes(); 
                planeCounter++; 
            }

        debugText.text = "floor y val: " + floorPlaneObject.transform.position.y.ToString();  


        // if (planeCounter == 5 & !boundsCreated) {
        //     CreateBounds(); 
        // }

        // if (planeCounter < 4) {
        //     debugText.text = "Click Map Wall next to a corner: " + planeCounter + "/4"; 
        //     mapButtonActive = true; 
        // } else if (planeCounter == 4 && Input.touchCount > 0) {
        //     mapButtonActive = false; 
        //     mapButton.SetActive(false); 
        //     debugText.text = "Select floor plane"; 
        //     RaycastHit hit;     
        //     Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position); 
        //     if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))  {
        //         if (Input.GetTouch(0).phase == TouchPhase.Began) {
        //             if (Physics.Raycast(ray, out hit)) {
        //                 floorPlane = (hit.collider.gameObject.GetComponent<ARPlane>());  
        //                 planeCounter++; 
        //             }
        //         }
        //     }
        // }

        // if (boundsCreated && !containerCreated) {
        //     CreateContainer(); 
        // }
    }

    bool boundsCreated; 
    void CreateBounds() {

        //get the two locations and extract their x and z to get the angle between them and 0, 0, 0


        var num = 0; 
        float maxX = 0; 
        float maxZ = 0; 
        float leastX = 0; 
        float leastZ = 0; 

        foreach(var loc in cornerLocations) {
            num++; 
            if (loc.x > maxX) {
                maxX = loc.x;  
            } else if (loc.x < leastX) {
                leastX = loc.x; 
            }

            if (loc.z > maxZ) {
                maxZ = loc.z;
            } else if (loc.z < leastZ) {
                leastZ = loc.z; 
            }
            Debug.Log("wall #" + num + ": " + loc); 
        }
        Debug.Log("floor plane: " + floorPlane.transform.position); 

        Debug.Log("max x: " + maxX);
        Debug.Log("least x: " + leastX);
        Debug.Log("maxZ: " + maxZ);
        Debug.Log("least z: " + leastZ); 

        boundsDictionary["max x"] = maxX; 
        boundsDictionary["min x"] = leastX; 
        boundsDictionary["max z"] = maxZ;
        boundsDictionary["min z"] = leastZ; 

        boundsCreated = true; 
    }

    [SerializeField]
    GameObject newGo;  
    bool containerCreated; 
    bool containerRotated; 
    void CreateContainer() {
        var count = 0; 

        //right now just hard coding in first two values but should add case for when two corners are chosen
        //because then it wont work (need two adjacent corners not oppposite ones)
        var directionalVector = cornerLocations[0] - cornerLocations[1]; 
        var rotation = Quaternion.Euler(directionalVector); 

        debugText.text = rotation.ToString(); 


        if (count == 0) {
            var containerParentObj = GameObject.Find("Container");
            //var newGo = new GameObject("max x");
            newGo = Instantiate(newGo);
            newGo.transform.parent = containerParentObj.transform; 
            newGo.transform.position = new Vector3(boundsDictionary["max x"], 0, 0); 
            newGo.transform.rotation = rotation; 
            newGo.AddComponent<BoxCollider>(); 
            var boxCollider = newGo.GetComponent<BoxCollider>();
            var xSize = Mathf.Abs(boundsDictionary["max z"]) + Mathf.Abs(boundsDictionary["min z"]); 
            newGo.transform.localScale = new Vector3(.1f, xSize, xSize); 
            boxCollider.size = new Vector3(.1f, xSize, xSize); 
            count++; 
        } 
        containerCreated = true;
    }

    [SerializeField]
    Slider slider; 
    public void SliderContainerAdjustment() {
        var rotationVal = slider.value;
        newGo.transform.rotation = Quaternion.Euler(0f, slider.value, 0f);  
    }

    
    public void ClickMapButton() {
        Debug.Log("yuh"); 
        cornerLocations.Add(arCam.transform.position); 
        planeCounter++; 
    }
}
