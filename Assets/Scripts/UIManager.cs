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

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject gameOverPanelWin;
    public GameObject gameOverPanelLose;

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


    private void Update()
    {
        targetText.text = GameManager.instance.targetCount.ToString();
        pointText.text = GameManager.instance.score.ToString();
    }


    IEnumerator ShowResultPanel(GameObject panel)
    {
        yield return new WaitForSeconds(3f);
    }
}
