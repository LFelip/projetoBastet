using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    //Pra saber se tem os itens
    private bool hasScepter = false;  
    private bool hasEarRing = false;  
    private bool hasAnk     = false;  

    public Image[] itemSlots;

    static LevelController instance;
    
    void Start()
    {
        if (instance == null )
        {
            instance = this;
        }
        
    }

    public GetItem(Sprite itemSprite)
    {
        foreach (Image itemSlot in itemSlots)
        {
            if (itemSlot.Sprite == null)
            {
                itemSlot.Sprite = itemSprite;
                itemSlot.SetEnable(true);
                break;
            } 
        }
    }

    
}
