using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	
	public 	Rigidbody2D rigidBody;
	public 	float 		forcaPulo;
	public	float		velocidade;
	public 	Animator	anim;
	public  float		phaseTimer;  
	public  MeshBlink 	meshblink;

	//controla a vida do cartepie
	public 	float		lifePoints;



	//para controle de virar
	public 	float 		turnTimer;
	public 	float		axis;

	//para Flip()
	public 	bool 		facingRight;

	//para verificar se player pisou na cabeça
	public 	bool			isDamaged;
	public	LayerMask		whatIsHero;
	public 	Transform		ceiling;


	// Use this for initialization
	void Start () {
		Random.seed = 2;
		phaseTimer = 0f;
			

	}
	
	// Update is called once per frame
	void Update () {

		//verifica se Player pisou na cabeça do inimigo
		if (phaseTimer <= 0) 
		{

			isDamaged = false;


			if (meshblink.enabled)
			{

				meshblink.enabled= false;
				meshblink.ResetColor();

			}

			if (Physics2D.OverlapCircle (new Vector2 (ceiling.position.x, ceiling.position.y), 0.04f, whatIsHero)) 
			{	
				isDamaged = true;
				phaseTimer = 1.5f;
				meshblink.enabled= true;
				lifePoints -=1;

			

			}

		}else phaseTimer -= Time.deltaTime;



		anim.SetBool("dano", isDamaged);	

			if (!isDamaged)
			rigidBody.velocity = new Vector2 ((axis * velocidade), 0);
		

			




		if (turnTimer > 0 && !isDamaged)
			{
		
			turnTimer-= Time.deltaTime;
			
			if (axis > 0 && !facingRight)
				Flip();
			else if (axis < 0 && facingRight)
				Flip();
			}

		else
		{

			turnTimer= (Random.value+1);
			axis= (axis * -1);

		}




		//verifica se morreu


		if (lifePoints ==  0) Destroy(this.gameObject);

	}



	void Flip()
	{
		facingRight = !facingRight;
		
		Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		
		transform.localScale = novoScale;
	}
	

}
