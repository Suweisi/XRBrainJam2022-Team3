using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Destination : MonoBehaviour
{   

    //take this thing's pos and make a radius around it 
    [SerializeField]
    GameObject[] destinationObjs; 

    [System.NonSerialized]
    DestinationManager destManager; 

    void Awake() {
        destManager = GameObject.FindGameObjectWithTag("posdes").GetComponent<DestinationManager>(); 
    }

    
    //how far stuff is away for it to be considered done

    /*
    - when something reaches destination
    - object disappears
    - increments a counter (destination manager)
    */

    void Update() {
        
        foreach(var destinationObj in destinationObjs) {
            if (Vector3.Distance(gameObject.transform.position, destinationObj.transform.position) < .1) {
                Debug.Log("put away"); 
                gameObject.SetActive(false); 
                destManager.numOfObjectsPutAway+=1; 
                Debug.Log("num of objects put away (from destination script)" + destManager.numOfObjectsPutAway); 
            }
        }
    }
}
