using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;



    // Start is called before the first frame update
    void Start()
    {
        UIFade.instance.FadeFromBlack();
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
        PlayerController.instance.ResumeMovement();
        GameManager.instance.fadingBetweenAreas = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
