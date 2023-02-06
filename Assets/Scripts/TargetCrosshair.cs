using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetCrosshair : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.targetCount > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
           gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
