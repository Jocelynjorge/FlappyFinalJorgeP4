using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    //Awake is called before start.
    private void Awake()
    {
        //Get and store a reference to the collider 2D attached to the ground 
        groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis 
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update runs once per frame 
    private void Update()
    {
        //check if the difference along the x axis between the main camera and the position of the object this is attached to is greater than groundHorizontalLength
        if (transform.position.x < -groundHorizontalLength)
        {
            //if true this means this object is no longer visable and we can safely move it foward 
            RepositionBackground();
        }
    }
    //moves this object is attached to right in order to create our looping background effect 
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background 
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        // Move this object from position offscreen behind the player to the new position off camera in front of the player 
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}


