using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI targetText;
    public TextMeshProUGUI pointText;
    public List<GameObject> hearts;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        targetText.text = GameManager.instance.targetCount.ToString();
        pointText.text = GameManager.instance.score.ToString();
    }
}
