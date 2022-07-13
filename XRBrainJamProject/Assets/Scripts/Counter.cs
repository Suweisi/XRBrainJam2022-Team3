using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Counter : MonoBehaviour
{
    [SerializeField]
    GameObject phoneCanvas; 
    [SerializeField]
    GameObject canvasAR; 
    [SerializeField]
    GameObject destManObj;
    [SerializeField]
    TMP_Text counterText; 

    void Update() {
        if (phoneCanvas.activeSelf) {
            canvasAR.SetActive(false);
        } else {
            canvasAR.SetActive(true);
        }

        counterText.text = destManObj.GetComponent<DestinationManager>().numOfObjectsPutAway.ToString();  

    }
}
