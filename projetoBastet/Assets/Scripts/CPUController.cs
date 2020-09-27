using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUController : MonoBehaviour
{
    public float distanciaPausa = 16.0f;
    public Transform target;

    public Rigidbody2D rgBody;

    private float delay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, target.position) > distanciaPausa)
            {
                rgBody.MovePosition(target.position);
            } 
        
    }

    private void FixedUpdate() {
        
    }
}
