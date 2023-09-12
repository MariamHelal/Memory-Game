using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class openLevels : MonoBehaviour
{
    public int level;

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());

    }
}
