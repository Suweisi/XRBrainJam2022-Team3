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
            if (phoneDist < 1) {
                RaycastHit hit; 
                Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject == phone) {
                        Debug.Log("hit the phone baby!!");  
                        phoneCanvas.SetActive(true);
                        gameObject.SetActive(false); 
                        GetComponent<EventTransitioner>().endConditionReached = true; 
                    }
                }
            }
        }

        if (phoneDist <  1f) {
            
        }

        // var phoneDist = Vector3.Distance(arCamera.transform.position, phone.transform.position); 
        // if (phoneDist > 3) {
        //     alpha = 1; 
        //     introPanelImage.color = new Color(0, 0, 0, alpha); 
        //     panelReadyImage.color = new Color(0, 0, 0, alpha); 
        // } else if (phoneDist < 2f) {
        //     panelReady.GetComponent<EventTransitioner>().endConditionReached = true; 
        //     phone.SetActive(false);
        // }  else if (phoneDist < 3 && phoneDist > 0) {
        //     alpha = 1 - (1 / phoneDist / 6); 
        //     introPanelImage.color = new Color(0, 0, 0, alpha); 
        //     panelReadyImage.color = new Color(0, 0, 0, alpha); 
        // }
    }
}
