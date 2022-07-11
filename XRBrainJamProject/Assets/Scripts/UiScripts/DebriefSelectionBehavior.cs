using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefSelectionBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject yesPanel; 
    [SerializeField]
    GameObject noPanel;

    public void PressYes() { 
        yesPanel.SetActive(true);
    }

    public void PressNo() {
        noPanel.SetActive(true); 
    }
 
}
