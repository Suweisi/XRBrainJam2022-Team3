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
    GameObject[] allPossibleDestinationObjects; 

    [System.NonSerialized]
    DestinationManager destManager; 
    [SerializeField]
    GameObject audioDing; 
    [SerializeField]
    GameObject incorrectAudioDing; 

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
        // foreach(var destinationObj in destinationObjs) {
        //     if (Vector3.Distance(gameObject.transform.position, destinationObj.transform.position) < .2f) {
        //         Debug.Log("put away"); 
        //         gameObject.SetActive(false);
        //         //gameObject.GetComponent<Collider>().enabled = false; 
        //         audioDing.GetComponent<AudioSource>().Play(); 
        //         destManager.numOfObjectsPutAway+=1; 
        //         Debug.Log("num of objects put away (from destination script)" + destManager.numOfObjectsPutAway); 
        //     }
        // }
    }

    void OnCollisionEnter(Collision collision) {
        GameObject collidedObj = collision.gameObject; 
        foreach(var obj in destinationObjs) {
            if (obj == collidedObj) {
                Debug.Log("yuh"); 
                //play thats right audio here, dont turn off the obj, and set the counter in destman up 1
                audioDing.GetComponent<AudioSource>().Play(); 
                destManager.numOfObjectsPutAway+=1; 
                collidedObj.GetComponent<Collider>().enabled = false;
                collidedObj.GetComponent<Rigidbody>().useGravity = false; 
                return; 
            }
        }
        foreach(var collided in allPossibleDestinationObjects) {
            if (collidedObj == collided) { 
                Debug.Log("if this is followed by a nuhh, no null ref"); 
                incorrectAudioDing.GetComponent<AudioSource>().Play(); 
                Debug.Log("nuhh"); 
            }  
        }
    }
}
