using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Bridge Bridge;
    private float time;

    private void OnTriggerEnter2D(Collider2D other) {
        Mushroom shroom = other.GetComponent<Mushroom>();

        if(time >= 1f){
            Bridge.Durability -= shroom.Weight;
            time = 0;
        }else{
            time += Time.deltaTime;
        }
    }
}
