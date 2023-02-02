using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType platformType;
    public bool isDetectPlayer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            collision.gameObject.GetComponent<Player>().isJump = false;
            isDetectPlayer = true;
            //collision.gameObject.GetComponent<Player>().destroyLoc = collision.gameObject.GetComponent<Player>().destroyer.transform.localPosition;
            //collision.gameObject.GetComponent<Player>().destroyPos = collision.gameObject.GetComponent<Player>().transform.localToWorldMatrix.MultiplyPoint3x4(collision.gameObject.GetComponent<Player>().destroyLoc);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            //isDetectPlayer = false;
        }
    }


}
