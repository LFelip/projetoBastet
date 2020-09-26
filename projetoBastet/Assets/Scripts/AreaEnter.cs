using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    public string transitionArea;
    // Start is called before the first frame update
    void Start()
    {
        if (transitionArea == PlayerController.instance.areaTransitionName) {
            PlayerController.instance.transform.position = transform.position;
        }

        UIFader.instance.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
