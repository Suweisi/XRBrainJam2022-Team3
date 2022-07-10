using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBehavior : MonoBehaviour
{

    GameObject[] arrayOfDraggableObjects; 
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
            }
        } 
    }


    void Update()
    {
        foreach(GameObject go in arrayOfDraggableObjects) {
            //Debug.Log(go.name); 
            var pref = go.transform.GetChild(0);
            var dragPrimProperties = pref.GetComponent<DragPrimProperties>(); 
            if (Vector3.Distance(arCamera.transform.position, pref.transform.position) < dragStateDistance) {
                dragPrimProperties.draggableStateActivated = true; 
                if (dragPrimProperties.rend.sharedMaterial != draggable) {
                    dragPrimProperties.rend.sharedMaterial = draggable;
                } 
            } else {
                dragPrimProperties.draggableStateActivated = false; 
                if (dragPrimProperties.rend.sharedMaterial != normal) {
                    dragPrimProperties.rend.sharedMaterial = normal;
                }
            }
        }
    }
}
