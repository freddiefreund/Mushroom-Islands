using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIslandMovement : MonoBehaviour
{
    public float amplitude;
    public float frequency;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos;
    void Start()
    {
        tempPos.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency)) * (amplitude/60f);

        transform.position = tempPos;
    }
}
