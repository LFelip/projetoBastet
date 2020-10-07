using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{   public string areaToLoad; 

    public float waitToLoad = 1f;

    private bool shouldWaitToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.tag == "Player")
        {
            if (LevelController.instance.CanGoNextLevel()) 
            {
              shouldWaitToLoad = true;    
            }
        }
    }
}