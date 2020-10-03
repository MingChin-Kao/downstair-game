using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageCam : MonoBehaviour
{
    public float downspeed; 
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.Translate(0, -downspeed * Time.deltaTime, 0);
    }
}
