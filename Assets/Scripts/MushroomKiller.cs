using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomKiller : MonoBehaviour
{
    public int KillCount;
    public int SavedCount;
    public TMP_Text KillCounter;
    public TMP_Text SavedCounter;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        // retarded
        Debug.Log("Collision detected");
        if(TryGetComponent(out ShroomMover shroom)){
            shroom.Die();
            KillCount++;
            UpdateUI();
        }else{
            other.gameObject.GetComponent<ShroomMover>().Die();
            KillCount++;
            UpdateUI();
        }
    }

    public void UpdateUI(){
        KillCounter.text = KillCount.ToString();
        SavedCounter.text = SavedCount.ToString();
    }
}
