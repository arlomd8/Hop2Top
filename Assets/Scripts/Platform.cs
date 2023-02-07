using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType platformType;
    public bool isDetectPlayer;
    public GameObject effect;
    public bool isAlreadyStepped;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            collision.gameObject.GetComponent<Player>().isJump = false;
            isDetectPlayer = true;
            effect.SetActive(true);
            UIManager.instance.jumpButton.SetActive(true);
            
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            effect.SetActive(false);
        }
    }


}
