using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{

    public static UIFader instance;
    public Image fadeScreen;
    public float fadeSpeed;

    public bool fadingIn;
    public bool fadingOut;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (fadingOut)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            fadingOut = !(fadeScreen.color.a == 1f);
        }   

        if (fadingIn)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            fadingIn = !(fadeScreen.color.a == 0f); 
        }     
    }

    public void FadeIn()
    {
        fadingIn = true;
        fadingOut = false;
    }

    public void FadeOut()
    {
        fadingIn = false;
        fadingOut = true;
    }
}
