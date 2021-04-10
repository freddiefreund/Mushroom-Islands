using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> islands;
    [SerializeField] private float spawnTime;
    [SerializeField] private static int numberOfSpawnedShrooms;
    [SerializeField] private GameObject shroomPrefab;
    [SerializeField] private float currentTime;
    
    void Start()
    {
        numberOfSpawnedShrooms = 0;
        currentTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= currentTime)
        {
            currentTime += spawnTime;
           // Debug.Log("Spawn Shroom!");
            SpawnShroom();
        }
    }

    void SpawnShroom()
    {
        // Get spawn position
        int startIslandID = Random.Range(0, islands.Count);
        Transform startIsland = islands[startIslandID];
        float xSpawnOffset = Random.Range(-1f, 1f);
        Vector3 spawnPosition = startIsland.position + new Vector3(xSpawnOffset, 0, 0);
        Debug.Log(startIsland.position);
        
        // Get destination 
        int destinationIslandID;
        do
        {
            destinationIslandID = Random.Range(0, islands.Count);
        } while (startIslandID == destinationIslandID);
        Transform destinationIsland = islands[destinationIslandID];
        Vector3 destinationPosition = destinationIsland.position;
        
        // Create Shroom
        GameObject spawnedShroom = Instantiate(shroomPrefab, spawnPosition, Quaternion.identity);
        ShroomMover script = spawnedShroom.GetComponent<ShroomMover>();
        script.SetDestination(destinationPosition.x);
        numberOfSpawnedShrooms++;
    }

    public static void RemoveShroom()
    {
        numberOfSpawnedShrooms--;
    }
}
