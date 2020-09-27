using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Tilemap theMap;

    //sets the limits of the map
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public PlayerController[] avaliableChar;

    private float halfHeight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f); 
        topRightLimit = theMap.localBounds.max - new Vector3(halfWidth, halfHeight, 0f);

        foreach (PlayerController currentChar in avaliableChar)
        {   
            currentChar.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);  

        //keep the camera inside the bounds

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }
}
