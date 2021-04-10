using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            if(transform.position.x <= -23.8f){
                return;
            }else{
                transform.position -= new Vector3(0.09f,0,0);
            }
        }
        if(Input.GetKey(KeyCode.D)){
           if(transform.position.x >= 19.5f){
                return;
            }else{
                transform.position += new Vector3(0.09f,0,0);
            }
        }
    }
}
