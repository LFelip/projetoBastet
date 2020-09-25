using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    
    public float moveSpeed2;
    public Rigidbody2D rigb2;
    private Vector2 direcao2;
    private bool troca2;
    public float Speed2;
    public float DistanciaPausa2;
    private Transform Target2;


    void Start()
    {
        Target2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            troca2 = !troca2;
        }

       if(!troca2)
        {
            moveSpeed2 = 1f;

            ProcessarInputs();
            Habilidade();

        }
        
        if(troca2)
        {
            moveSpeed2 = 0f; 

            if(Vector2.Distance(transform.position, Target2.position) > DistanciaPausa2)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target2.position, Speed2 * Time.deltaTime);
            } 
      
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
