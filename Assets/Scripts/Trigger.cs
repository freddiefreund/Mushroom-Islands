using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Bridge Bridge;
    private float time;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Entered the trigger");
        Mushroom shroom = other.GetComponent<Mushroom>();
        Bridge.Durability -= shroom.Weight;
    }
}
