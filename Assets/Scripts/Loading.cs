using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float i;
    public TextMeshProUGUI text;
    void Start()
    {
        i = 0;
    }

    void Update()
    {
        
        if (i < 100)
        {
            i += Time.deltaTime * 50f;
            text.text = $"Preparing the game: {i.ToString("00")}%";
        }
        else
        {
            text.text = $"Completed: 100%";
            StartCoroutine(LoadGame());
        }

        
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level");
        
    }
}
