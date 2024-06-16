using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public GameObject entity;
    public PotionData potion;
    public PotionData potionTwo;
    int instanceNumber = 1;

    void Start()
    {
        SpawnPotions(potion, "HealthPot", 30);
        SpawnPotions(potionTwo, "PoisonPot", 30);
    }

    void SpawnPotions(PotionData potionData, string tag, int sortingOrder)
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < potionData.numberOfPrefabsToCreate; i++)
        {
            Vector3 spawnPosition = potionData.spawnPoints[currentSpawnPointIndex];
            spawnPosition.z = -1; // Ensure in front of tilemap
            GameObject currentEntity = Instantiate(entity, spawnPosition, Quaternion.identity);
            SpriteRenderer sr = currentEntity.GetComponent<SpriteRenderer>();

            
            sr.sortingOrder = sortingOrder;
            sr.color = potionData.potionTint;
            
            currentEntity.tag = tag;
            currentEntity.name = potionData.prefabName + instanceNumber;

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % potionData.spawnPoints.Length;
            instanceNumber++;
        }
    }
}
