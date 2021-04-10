using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Bridge : MonoBehaviour, IPointerClickHandler
{
    public float Durability = 100f;
    public GameObject popupText;
    public float distance = 10f;


    void Update()
    {
        if (Durability <= 0){
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData pointer){
        Durability += 2;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
        Vector3 point = ray.origin + (ray.direction * distance);
        Instantiate(popupText, point, Quaternion.identity);
        popupText.transform.GetChild(0).GetComponent<TextMeshPro>().text = "repaired!";
        if(Durability > 100){
            Durability = 100;
        }
    }
    
}
