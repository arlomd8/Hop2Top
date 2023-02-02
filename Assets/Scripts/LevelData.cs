using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Level", menuName = "Level", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int pillar;

    [SerializeField]
    private int target;

    [SerializeField]
    private int bonusTarget;


    public int Pillar
    {
        get { return pillar; }
    }
    public int Target
    {
        get { return target; }
    }
    public int BonusTarget
    {
        get { return bonusTarget; }
    }
}

