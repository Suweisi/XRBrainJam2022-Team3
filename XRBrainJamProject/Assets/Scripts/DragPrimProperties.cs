using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPrimProperties : MonoBehaviour
{
    public bool draggableStateActivated;
    public Renderer rend;

    void Awake() {
        draggableStateActivated = false; 
        rend = gameObject.GetComponent<Renderer>(); 
    }
}
