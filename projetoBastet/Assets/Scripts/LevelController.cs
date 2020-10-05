using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelController : MonoBehaviour
{
    //Pra saber se tem os itens
    private bool hasScepter = false;  
    private bool hasEarRing = false;  
    private bool hasAnk     = false;  

    public Image[] itemSlots;

    public static LevelController instance;
    
    void Start()
    {
        if (instance == null )
        {
            instance = this;
        }
        
    }

    public void GetItem(Sprite itemSprite)
    {
        foreach (Image itemSlot in itemSlots)
        {
            if (itemSlot.sprite == null)
            {
                itemSlot.sprite = itemSprite;
                itemSlot.enabled = true;
                break;
            } 
        }
    }

    
}
