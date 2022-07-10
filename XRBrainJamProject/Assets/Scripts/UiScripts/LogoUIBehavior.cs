using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LogoUIBehavior : MonoBehaviour
{

    Image image;
    float alphaVal; 

    void Awake() {
        image = GetComponent<Image>(); 
        alphaVal = image.color.a; 
    }
}
