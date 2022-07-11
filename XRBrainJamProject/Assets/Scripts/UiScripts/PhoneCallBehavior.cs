using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallBehavior : MonoBehaviour
{
    public void PressAnswerButton() {
        GetComponent<EventTransitioner>().endConditionReached = true; 
        gameObject.SetActive(false);
    }
}
