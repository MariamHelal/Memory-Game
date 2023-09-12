using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonsScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void OpenLevelScene()
    {
        SceneManager.LoadScene("Scene Levels");
    }
    public void loadBreviousLevel()
    {
        int breviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(breviousSceneIndex - 1);
    }
  //  public void loadNextLevel()
    //{
        
      //  int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(nextSceneIndex + 1);
    //}
    public void HomeButton()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
