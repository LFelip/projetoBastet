using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador2 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rigb;
    private Vector2 direcao;
    private bool troca;


    void Start()
    {

    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F)) 
        {
            troca = !troca;
        }

       if(troca == false)
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

        direcao = new Vector2(moveX, moveY);
    }

    void Movimentar()
    {
        rigb.velocity = new Vector2(direcao.x * moveSpeed, direcao.y * moveSpeed);
    }

    void Habilidade()
    {

    }
}
