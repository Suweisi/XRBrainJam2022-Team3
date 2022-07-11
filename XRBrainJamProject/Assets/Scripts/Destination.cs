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
    GameObject postiveDestinationManagerObject;
    [SerializeField]
    GameObject negativeDestinationManagerObject; 
    [System.NonSerialized]
    public GameObject destinationManagerObject; 

    [System.NonSerialized]
    public DestinationManager destManager; 

    // void Awake() {
    //     destManager = postiveDestinationManagerObject.GetComponent<DestinationManager>(); 
    // }

    
    //how far stuff is away for it to be considered done

    /*
    - when something reaches destination
    - object disappears
    - increments a counter (destination manager)
    */

    [SerializeField]
    TMP_Text debugText; 

    void Update() {

        // if (postiveDestinationManagerObject.activeSelf) {
        //     destinationManagerObject = postiveDestinationManagerObject; 
        // } else if (negativeDestinationManagerObject.activeSelf) {
        //     destinationManagerObject = negativeDestinationManagerObject;
        // } else {
        //     Debug.Log("yodalayheehoo"); 
        //     return; 
        // }

        foreach(var destinationObj in destinationObjs) {
            if (Vector3.Distance(gameObject.transform.position, destinationObj.transform.position) < .1) {
                Debug.Log("put away"); 
                gameObject.SetActive(false); 
                destManager.numOfObjectsPutAway+=1; 
            }
        }
    }
}
