using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        ChangeSceneString("Loading");
    }


    public void MuteAudio()
    {
        FindObjectOfType<AudioManager>().Mute();
    }
    public void UnMuteAudio()
    {
        FindObjectOfType<AudioManager>().UnMute();
    }

    public void ButtonClick()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void EnableAudio(Image img)
    {
        if (!FindObjectOfType<AudioManager>().isMute)
        {
            MuteAudio();
            img.color = Color.black;
        }
        else
        {
            UnMuteAudio();
            img.color = Color.white;
        }
    }
}
