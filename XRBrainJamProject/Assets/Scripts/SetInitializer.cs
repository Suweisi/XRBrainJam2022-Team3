using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitializer : MonoBehaviour
{

    [SerializeField]
    GameObject planeManager; 
    float yGroundVal; 
    void Awake() {
        yGroundVal = planeManager.GetComponent<PlaneContainer>().yGroundValue;  
        gameObject.transform.position = new Vector3(0f, yGroundVal, 0f); 
    }
}
