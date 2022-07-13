using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefOneBehavior : MonoBehaviour
{   

    [SerializeField]
    GameObject setObj; 

    void Awake() {
        setObj.SetActive(false); 
    }

     public void PressNote() {
        GetComponent<EventTransitioner>().endConditionReached = true; 
        gameObject.SetActive(false); 
    }
}
