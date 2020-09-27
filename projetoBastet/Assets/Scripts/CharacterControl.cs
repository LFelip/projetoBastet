using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Controla a troca de personagens
public class CharacterControl : MonoBehaviour
{
    static CharacterControl instance;
    
    //define qual personagem esta ativo
    public int activeChar = 0;  
    private int nextChar = 1;
    

    public GameObject[] avaliableChars;
    // Start is called before the first frame update

    public CameraController camera;

    void Start()
    {
        if (instance == null )
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2")) {
            TrocaChar();
        }    
    }

    void TrocaChar () {
    
        Transform charTransform = avaliableChars[activeChar].GetComponent<Transform>();
        
        Vector2 posicaoAtual = charTransform.position;

        avaliableChars[activeChar].SetActive(false);
        
        avaliableChars[nextChar].GetComponent<Transform>().position = posicaoAtual;
        avaliableChars[nextChar].SetActive(true);

        int auxChar = nextChar;
        nextChar = activeChar;
        activeChar = auxChar;

        camera.target = avaliableChars[activeChar].GetComponent<Transform>();
        camera.activeController = avaliableChars[activeChar].GetComponent<PlayerController>();

        
    }
}

