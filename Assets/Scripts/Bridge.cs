using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float Durability = 100f;


    void Update()
    {
        if (Durability <= 0){
            Destroy(gameObject);
        }
    }
}
