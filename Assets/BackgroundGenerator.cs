using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject background;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Spawn();
    }

    public void Spawn()
    {
        if(background.GetComponent<SpriteRenderer>().bounds.size.x - screenBounds.x < 0)
        {
            Instantiate(background, new Vector2(background.GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y), Quaternion.identity);
        }
    }
}
