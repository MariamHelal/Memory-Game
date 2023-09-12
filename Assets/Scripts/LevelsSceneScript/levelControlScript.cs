using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class levelControlScript : MonoBehaviour
{
   
    public Button [] levelButtons;
    int levelsUnlocked;
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        for(int i=1;i<levelButtons.Length;i++)
        {
            levelButtons[0].interactable = true;
            levelButtons[i].interactable = false;
            
        }
        for(int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].interactable = true;

        }
    } 




    public void loadBreviousScene()
    {
        int breviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(breviousSceneIndex - 1);
    }
    public void resetPlayerPrefs()
    {
        for(int i = 1; i < levelButtons.Length; i++)
        {
            
            levelButtons[i].interactable = false;

        }
        PlayerPrefs.DeleteAll();
    }
}
