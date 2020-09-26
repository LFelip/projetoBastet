using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad; 

    public string areaTransitionName;

    public AreaEnter entrance;

    public float waitToLoad = 1f;

    private bool shouldWaitToLoad;

    // Start is called before the first frame update
    void Start()
    {
        entrance.transitionArea = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldWaitToLoad)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0 )
            {
                shouldWaitToLoad = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
    
        if (other.tag == "Player"){

            shouldWaitToLoad = true;
            UIFader.instance.FadeOut();
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
