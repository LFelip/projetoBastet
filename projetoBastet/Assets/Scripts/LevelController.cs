using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelController : MonoBehaviour
{
    const int goalRelics = 3;

    //Pra saber se tem os itens
    public int relicCount = 0;

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
                relicCount++;
                break;
            } 
        }
    }

    public bool CanGoNextLevel() 
    {
        return (relicCount == goalRelics);
    }

    
}
