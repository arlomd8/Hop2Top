using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonScript : MonoBehaviour
{
    public void ChangeScene(int name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeSceneString(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void LevelData(LevelData level)
    {
        FindObjectOfType<LevelManager>().levelData = level;
        ChangeSceneString("Level");
    }

}
