using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI scoreTextGameOver;
    public TextMeshProUGUI levelTextGameOver;

    public int time;
    public bool isWin;


    public void Start()
    {
        scoreText.text = UIManager.instance.pointText.text;
        levelText.text = GameManager.instance.levelData.name;
        StartCoroutine(ShowGameOverPanel());
        if (isWin) 
        { 
            FindObjectOfType<AudioManager>().Play("Win"); 
        }
        else 
        { 
            FindObjectOfType<AudioManager>().Play("Lose"); 
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        
        yield return new WaitForSeconds(1f);
        time--;
        countdownText.text = $"lanjut dalam ({time} detik)";
        StartCoroutine(ShowGameOverPanel());

        if (time == 0)
        {
            if (isWin)
            {
                GameManager.instance.score += 100;
                LevelManager.instance.cumulativeScore += GameManager.instance.score;
                scoreText.text = LevelManager.instance.cumulativeScore.ToString();
            }
            else
            {
                LevelManager.instance.cumulativeScore += GameManager.instance.score;
                scoreText.text = LevelManager.instance.cumulativeScore.ToString(); 
            }
            scoreTextGameOver.text = scoreText.text;
            levelTextGameOver.text = levelText.text;
            gameOverPanel.SetActive(true);
        }
    }
}
