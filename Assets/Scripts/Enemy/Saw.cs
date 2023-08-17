using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 2f;
    int dir = 1;

    public Transform rightCheck;
    public Transform leftCheck;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right* speed*dir*Time.fixedDeltaTime);
        
        //create a 2 unit raycast line down from the rightcheck object , if it touches an object like a platform it returns true and false if not.
        if(Physics2D.Raycast(rightCheck.position,Vector2.down,2)==false)
        {
            dir = -1;//moves left
        }

        //create a 2 unit raycast line down from the leftCheck object , if it touches an object like a platform it returns true and false if not.
        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 2) == false)
        {
            dir = 1;//moves right
        }
    }
}
