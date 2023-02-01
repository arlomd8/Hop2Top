using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelData levelData;

    public List<GameObject> platforms;
    

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    private void Start()
    {
        //Spawn Platform
        AddPlatformToList();
    }

    void AddPlatformToList()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Plat"))
        {
            platforms.Add(g);
        }
    }

    public void SpawnPlatform() { }


}
