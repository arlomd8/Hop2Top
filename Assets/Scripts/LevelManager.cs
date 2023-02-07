using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public LevelData levelData;

    public List<bool> levelCompleted;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


}
