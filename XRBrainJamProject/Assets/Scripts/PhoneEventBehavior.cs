using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PhoneEventBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Camera arCamera; 
    [SerializeField]
    GameObject panelReady; 
    [SerializeField]
    GameObject introPanel; 
    [SerializeField]
    GameObject phone; 
    Image introPanelImage; 
    Image panelReadyImage; 
    float alpha; 

    void Awake() {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>(); 
        panelReadyImage = panelReady.GetComponent<Image>(); 
        introPanelImage = introPanel.GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var phoneDist = Vector3.Distance(arCamera.transform.position, phone.transform.position); 
        if (phoneDist > 3) {
            alpha = 1; 
            introPanelImage.color = new Color(0, 0, 0, alpha); 
            panelReadyImage.color = new Color(0, 0, 0, alpha); 
        } else if (phoneDist < .6f) {
            panelReady.GetComponent<EventTransitioner>().endConditionReached = true; 
            phone.SetActive(false);
        }  else if (phoneDist < 3 && phoneDist > 0) {
            alpha = 1 - (1 / phoneDist / 6); 
            introPanelImage.color = new Color(0, 0, 0, alpha); 
            panelReadyImage.color = new Color(0, 0, 0, alpha); 
        }
    }
}
