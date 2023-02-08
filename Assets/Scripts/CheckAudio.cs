using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAudio : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }
    private void Update()
    {
        if (FindObjectOfType<AudioManager>().isMute)
        {
            img.color = Color.black;
        }
        else
        {
            img.color = Color.white;
        }
    }

}
