using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bridge : MonoBehaviour, IPointerClickHandler
{
    public float Durability = 100f;


    void Update()
    {
        if (Durability <= 0){
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData pointer){
        Durability += 2;
        if(Durability > 100){
            Durability = 100;
        }
    }
    
}
