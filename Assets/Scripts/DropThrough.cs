using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThrough : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float fallDelay = 0.25f;
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        waitTime = fallDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S)){
            effector.rotationalOffset = 0f;  
            waitTime = fallDelay;          
        }
        if(Input.GetKey(KeyCode.S)){
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = fallDelay;
            }else{
                waitTime -= Time.deltaTime;
            }
        }
    }
}
