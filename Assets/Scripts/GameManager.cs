using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelData levelData;
    private Player player;

    [Header("LEVEL")]
    public int score;
    public int targetCount;
    public int bonusTarget;
    public int platformCount;
    public bool isWin;
    public bool levelCompleted;

    [Header("PLATFORMS")]
    public List<GameObject> platforms;
    public float yPlatPos;
    public float xPlatPos;
    public float platPosXY;
    public GameObject platPrefab;
    public int lastPlatforms;

    [Header("BONUS ITEM")]
    public GameObject itemPrefab;

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    private void Start()
    {
        player = FindObjectOfType<Player>();
        levelData = LevelManager.instance.levelData;


        AssignLevelData();
        SpawnPlatform(platformCount);
        AddPlatformToList();
        SpawnPlayer();
        SpawnItem(bonusTarget);
    }

    private void Update()
    {
        for(int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].GetComponent<Platform>().isDetectPlayer)
            {
                lastPlatforms = i;
                try
                {
                    if (platforms[i + 1].GetComponent<Platform>().platformType == PlatformType.Right)
                    {
                        player.isLeft = false;
                        player.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        player.isLeft = true;
                        player.GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    continue;
                }
            }

            //if (lastPlatforms < i) { platforms[i].GetComponent<Collider2D>().isTrigger = true; }
        }

        if (lastPlatforms == platformCount - 1 && !isWin)
        {
            GameWin();
        }
    }

    void GameWin()
    {
        isWin = true;
        GameManager.instance.score += 100;
        UIManager.instance.winPanel.SetActive(true);
    }

    void SpawnPlayer()
    {
        player.gameObject.transform.position = new Vector2(platforms[0].transform.position.x, platforms[0].transform.position.y + .5f);
    }

    public void ResetPlayerPosition()
    {
        player.gameObject.transform.position = new Vector2(platforms[lastPlatforms].transform.position.x, platforms[lastPlatforms].transform.position.y + .5f);
    }

    void SpawnItem(int count)
    {
        int pos = 0;
        for (int i = 1; i <= count; i++)
        {
            var newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            pos += 5;
            newItem.transform.position = new Vector2(platforms[pos].transform.position.x, platforms[pos].transform.position.y + .5f);
        }
    }
    void AssignLevelData()
    {
        targetCount = levelData.Target;
        bonusTarget = levelData.BonusTarget;
        platformCount = levelData.Pillar;
    }
    void AddPlatformToList()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Plat"))
        {
            platforms.Add(g);
        }
    }

    public void SpawnPlatform(int count) 
    { 

        for(int i = 0; i < count; i++)
        {
            var newPlat = Instantiate(platPrefab, transform.position, Quaternion.identity);
            
            int x = Random.Range((int)PlatformType.Right, (int)PlatformType.None);

            if(x == (int)(PlatformType.Right))
            {
                newPlat.transform.position = new Vector3(xPlatPos += platPosXY, yPlatPos, 0);
                newPlat.GetComponent<Platform>().platformType = PlatformType.Right;
            }
            else
            {
                newPlat.transform.position = new Vector3(xPlatPos -= platPosXY, yPlatPos, 0);
                newPlat.GetComponent<Platform>().platformType = PlatformType.Left;
            }
            yPlatPos += platPosXY;
        }
    }

    public void LevelCompleted()
    {
        if (levelData.name == "Level 1")
        {
            LevelManager.instance.levelCompleted[0] = true;
        }

        if (levelData.name == "Level 2")
        {
            LevelManager.instance.levelCompleted[1] = true;
        }
    }
}
