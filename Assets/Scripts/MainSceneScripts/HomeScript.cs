using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void OpenScene()
    {
        SceneManager.LoadScene("Scene Levels");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void FollowUs()
    {
        Application.OpenURL("https://www.facebook.com/maryam.helal.96?mibextid=ZbWKwL");
    }
}
