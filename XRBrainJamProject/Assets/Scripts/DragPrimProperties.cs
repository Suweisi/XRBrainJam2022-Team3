using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPrimProperties : MonoBehaviour
{   
    [System.NonSerialized]
    public bool draggableStateActivated;
    [System.NonSerialized]
    public Renderer rend;

    void Awake() {
        draggableStateActivated = false; 
        rend = gameObject.GetComponent<Renderer>(); 
    }
}
