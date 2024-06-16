using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
public class CardDisplay : MonoBehaviour
{
    public GameObject statsCard;
    public TMP_Text npcName, description, armor, age, friendliness;
    public Image artwork;

    public GameObject gameoverMenu;

    public void showCharCard(npcInfo stats)
    {
       
        statsCard.SetActive(true);
        npcName.text = "My name is " + stats.npcName;
        description.text = stats.description;
        armor.text = stats.armourLevelm.ToString();
        age.text = "I am " + stats.age + " years old.";
        artwork.sprite = stats.npcSprite;

        if (stats.isFriendly)
        {
            friendliness.text = "Stay calm, I shall assist";

        }
        else friendliness.text = "I will drag you to hell";
    }
    public void gameOvermenu()
    {
        gameoverMenu.SetActive(true);
    }
    public void quitGame()
    {
#if UNITY_EDITOR   
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
   
}
