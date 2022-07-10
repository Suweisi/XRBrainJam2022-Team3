using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Destination : MonoBehaviour
{   

    //take this thing's pos and make a radius around it 
    [SerializeField]
    GameObject[] destinationObjs; 
    [SerializeField]
    GameObject destinationManager; 
    
    //how far stuff is away for it to be considered done

    /*
    - when something reaches destination
    - object disappears
    - increments a counter (destination manager)
    */

    [SerializeField]
    TMP_Text debugText; 

    void Update() {

        foreach(var destinationObj in destinationObjs) {
            if (Vector3.Distance(gameObject.transform.position, destinationObj.transform.position) < .1) {
                debugText.text = gameObject.name + " disappear homie"; 
                gameObject.SetActive(false); 
            }
        }
    }
}
