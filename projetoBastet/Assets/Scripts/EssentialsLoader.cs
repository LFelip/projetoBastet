using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject player;

    public GameObject UIScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if (UIFader.instance == null)
        {
            UIFader.instance = Instantiate(UIScreen).GetComponent<UIFader>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
