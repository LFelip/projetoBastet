using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    
    public float moveSpeed2 = 5f;
    public Rigidbody2D rigb2;
    private Vector2 direcao2;
    private bool troca2;


    void Start()
    {
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            troca2 = !troca2;
        }

       if(troca2 == true)
        {
            ProcessarInputs();
            Habilidade();
        }


    }

    void FixedUpdate()
    {
        Movimentar();
    }

    void ProcessarInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direcao2 = new Vector2(moveX, moveY);
    }

    void Movimentar()
    {
        rigb2.velocity = new Vector2(direcao2.x * moveSpeed2, direcao2.y * moveSpeed2);
    }

    void Habilidade()
    {

    }

}
