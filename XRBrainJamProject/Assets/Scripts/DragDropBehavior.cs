using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBehavior : MonoBehaviour
{

    GameObject[] arrayOfDraggableObjects; 
    List<GameObject> interactableObjects = new List<GameObject>(); 
    [SerializeField]
    GameObject arCamera;  
    [SerializeField]
    Material normal; 
    [SerializeField]
    Material draggable; 
    public float dragStateDistance; 

    void Awake() {
        arrayOfDraggableObjects = GameObject.FindGameObjectsWithTag("dragObject"); 
        foreach(var go in arrayOfDraggableObjects) {
            if (go.transform.GetChild(0) == null) {
                Debug.Log("error with: " + go.name); 
            } else {
                Debug.Log(go.name +  "is good");
                interactableObjects.Add(go); 
            }
        } 
        Debug.Log(interactableObjects.Count); 
        Debug.Log(interactableObjects[0]); 
    }

    GameObject lastgo; 
    void Update()
    {
        // Debug.Log("last object recorded: " + lastgo); 
        // foreach(GameObject go in interactableObjects) {
        //     var pref = go.transform.GetChild(0); 
        //     var dragPrimProperties = pref.GetComponent<DragPrimProperties>(); 
        //     Debug.Log(dragPrimProperties.draggableStateActivated); 
        //     // Debug.Log("here"); 
        //     if (Vector3.Distance(arCamera.transform.position, pref.transform.position) < dragStateDistance) { 
        //         dragPrimProperties.draggableStateActivated = true; 
        //         if (dragPrimProperties.rend.sharedMaterial != draggable) {
        //             dragPrimProperties.rend.sharedMaterial = draggable;
        //         } 
        //     } else {
        //         Debug.Log("in the else statement"); 
        //         // Debug.Log("woo"); 
        //         // Debug.Log(go.name + ": " + dragPrimProperties.draggableStateActivated); 
        //         dragPrimProperties.draggableStateActivated = false; 
        //         Debug.Log("this is prolly null: " + dragPrimProperties.rend.sharedMaterial); 
        //         if (dragPrimProperties.rend.sharedMaterial != normal) {
        //             Debug.Log("made it here as well"); 
        //             dragPrimProperties.rend.sharedMaterial = normal;
        //         }
        //     }
        //     lastgo = go; 
        // }
    }
}
