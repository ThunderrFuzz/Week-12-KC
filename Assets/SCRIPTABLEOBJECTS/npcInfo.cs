using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCInfo", order = 2)]
public class npcInfo : ScriptableObject
{
    public string npcName, description;
    public Sprite npcSprite;
    public int armourLevelm, age;
    public bool isFriendly;
}
