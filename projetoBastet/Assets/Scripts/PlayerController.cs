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

    // Start is called before the first frame update
    void Start(){
        if (instance == null){
            instance = this;
        } else {

            if (instance != this)
            {
                Destroy(gameObject);
            }  
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update(){
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        playerAnim.SetFloat("moveX", playerRB.velocity.x);
        playerAnim.SetFloat("moveY", playerRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        };

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3 (1f, 1f, 0);
        topRightLimit = topRight - new Vector3(1f, 1f, 0);
    }
}
