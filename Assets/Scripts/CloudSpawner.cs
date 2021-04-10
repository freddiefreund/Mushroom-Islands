using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject BigBackground;
    public GameObject SmallBackground;
    public GameObject BigForeground;
    public GameObject SmallForeground;

    public GameObject BigBackCloud;
    public GameObject SmallBackCloud;
    public GameObject BigForeCloud;
    public GameObject SmallForeCloud;


    private void Start() {
        StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds(){
        while(true){
            Instantiate(BigBackCloud, BigBackground.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
            Instantiate(SmallForeCloud, SmallForeground.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Instantiate(SmallBackCloud, SmallBackground.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(4);
            Instantiate(BigForeCloud, BigForeground.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(15);
        }

    }
    
}
