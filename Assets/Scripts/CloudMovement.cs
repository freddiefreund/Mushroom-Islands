using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float Speed = 1f;
    public bool RandomSpeed = false;

    private void Start() {
        if (RandomSpeed){
            Speed = Random.Range(0.05f, 1f);
        }
    }
    void Update()
    {
        float xPos = transform.position.x + Speed * Time.deltaTime;
        transform.position = new Vector2(xPos, transform.position.y);

        if(transform.position.x >= 36){
            Destroy(gameObject);
        }
    }
}
