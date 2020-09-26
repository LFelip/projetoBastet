using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador2 : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rigb;
    private Vector2 direcao;
    private bool troca;
    public float Speed;
    public float DistanciaPausa;
    private Transform Target;


    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            troca = !troca;
        }

       if(troca)
        {
            moveSpeed = 1f;

            ProcessarInputs();
            Habilidade();
        }

        if(!troca)
        {
            
            moveSpeed = 0f;

            if(Vector2.Distance(transform.position, Target.position) > DistanciaPausa)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
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
