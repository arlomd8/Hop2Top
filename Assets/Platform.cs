using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType platformType;

    private void Start()
    {
        //RandomEnum();
        
    }

    void RandomEnum()
    {
        platformType = (PlatformType)Random.Range((int)PlatformType.Right, (int)PlatformType.None);
    }



}
