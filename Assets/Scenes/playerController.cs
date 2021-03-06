using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float forceX;
    Rigidbody2D playerRigidBody2D;
    readonly float toLift = -1;
    readonly float toRight = 1;
    readonly float stop = 0;
    float directionX;
    void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
        	directionX = toLift;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            directionX = toRight;
        }else{
        	directionX = stop;
        }

        Vector2 newDirection = new Vector2(directionX, 0);
        playerRigidBody2D.AddForce(newDirection*forceX);

    }
}
