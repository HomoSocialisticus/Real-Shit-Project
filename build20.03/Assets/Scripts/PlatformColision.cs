using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColision : MonoBehaviour {

    private PlatformEffector2D effector;
    public float waitTime;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetButtonUp("Jump off"))
        {
            waitTime = 0.1f;
        }

        if(Input.GetButton("Jump off"))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetButton("Jump"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
