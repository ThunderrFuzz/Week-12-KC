using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject entity;
    public SpawnManagerScriptableObject spawnManagerValues;
    int instanceNumber = 1;
        
        // Start is called before the first frame update
    void Start()
    {
        spawnEntities();
    }
    void spawnEntities()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            //spawns objects
            GameObject currentEntity = Instantiate(entity, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);
            // sets spawned objects above backgrounds
            currentEntity.GetComponent<SpriteRenderer>().sortingOrder = 50;
            // Names object with I. 
            currentEntity.name = spawnManagerValues.prefabName + instanceNumber;

            // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;
            //increments instance number
            instanceNumber++;
        }
    }
}
