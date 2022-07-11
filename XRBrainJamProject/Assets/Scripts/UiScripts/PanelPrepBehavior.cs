using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPrepBehavior : MonoBehaviour
{
    public void PanelPrepReadyButtonPress() {
        gameObject.SetActive(false); 
        GetComponent<EventTransitioner>().endConditionReached = true; 
    }
}
