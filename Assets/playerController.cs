using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float forceX;
    Animator anim;
    Rigidbody2D playerRigidBody2D;
    public static bool isDead;
    readonly float toLift = -1;
    readonly float toRight = 1;
    readonly float stop = 0;
    float directionX;
    float jumpForce = 30.0f;
    Rigidbody2D rigid2D;

    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.CompareTag("dead")){
            isDead = true;
        }
        this.rigid2D = GetComponent<Rigidbody2D>();

    }


    void Start()
    {   
        anim = GetComponent<Animator>();
        isDead=false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftArrow)){
        	directionX = toLift;
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(-1,1,1);

        }else if(Input.GetKey(KeyCode.RightArrow)){
            directionX = toRight;
            anim.SetBool("isRunning", true);
            transform.localScale = new Vector3(1,1,1);
        }else if(Input.GetKey(KeyCode.UpArrow)){
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }else{
            anim.SetBool("isRunning", false);
        	directionX = stop;
        }

        Vector2 newDirection = new Vector2(directionX, 0);
        playerRigidBody2D.AddForce(newDirection*forceX);

    }
}
