using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PhoneEventBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Camera arCamera; 
    [SerializeField] 
    GameObject phoneCanvas; 
    [SerializeField]
    GameObject phone; 
    [Header("Audio")]
    
    [SerializeField]
    GameObject wherePhoneObject; 
    float phoneDist; 

    void Awake() {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
        wherePhoneObject.GetComponent<AudioSource>().Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        phoneDist = Vector3.Distance(arCamera.transform.position, phone.transform.position); 

        if (Input.touchCount > 0) {
            RaycastHit hit; 
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == phone) {
                    phoneCanvas.SetActive(true);
                    gameObject.SetActive(false); 
                    phone.SetActive(false); 
                    GetComponent<EventTransitioner>().endConditionReached = true; 
                }
            }
        }
    }
}
