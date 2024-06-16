using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PotionData", order = 3)]

public class PotionData : ScriptableObject
{
    public string prefabName;
    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;

    public Color potionTint;
    public string potionText;
    public float damage;
    public float heal;
}
