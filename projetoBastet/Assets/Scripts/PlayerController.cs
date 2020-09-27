using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Rigidbody2D playerRB;

    public float moveSpeed;

    public Animator playerAnim;

    public static PlayerController instance;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public string areaTransitionName;

    public bool facingRight;

    // Start is called before the first frame update
    void Start(){
        if (instance == null)
        {
            instance = this;
        } 
    }

    // Update is called once per frame
    void Update(){
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        playerAnim.SetFloat("moveSpeedX", playerRB.velocity.x);
        playerAnim.SetFloat("moveSpeedY", playerRB.velocity.y);

        if (facingRight && playerRB.velocity.x < 0) 
        {
            Flip();
        }
        else if (!facingRight && playerRB.velocity.x > 0)
        {
            Flip();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3 (1f, 1f, 0);
        topRightLimit = topRight - new Vector3(1f, 1f, 0);
    }

    void Flip()
	{
		facingRight = !facingRight;
		
		Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		
		transform.localScale = novoScale;
	}
}

