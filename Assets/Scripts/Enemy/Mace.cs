using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3f;

    float startingY ;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y; 
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime*direction);
    
        if (transform.position.y <  startingY || transform.position.y > range) 
        {
            direction *= -1;
            //at start neither condition is satisfied and direction = 1 so Mace moves up, on transform.position.y > range direction =-1 and Mace moves down
        }
    }
}
