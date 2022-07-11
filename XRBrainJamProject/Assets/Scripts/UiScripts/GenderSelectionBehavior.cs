using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenderSelectionBehavior : MonoBehaviour
{
    public void OnGenderScreenNextButtonPress() {
        gameObject.SetActive(false); 
        GetComponent<EventTransitioner>().endConditionReached = true; 
    }
}
