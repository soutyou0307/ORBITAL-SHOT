using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int killCount = 0;
    public static int score = 0;

    public int clearKillCount = 10;
    public int scorePerKill = 100;

    public TextMeshProUGUI scoreText;

    private bool isGameEnded = false;

    void Start()
    {
        killCount = 0;
        score = 0;
        isGameEnded = false;
        ResultManager.isClear = false;

        UpdateScoreUI();
    }

    public void AddKill()
    {
        if (isGameEnded) return;

        killCount++;
        score += scorePerKill;

        Debug.Log("撃破数：" + killCount + "/" + clearKillCount);
        Debug.Log("スコア：" + score);

        UpdateScoreUI();
        /*
        if (killCount >= clearKillCount)
        {
            isGameEnded = true;
            ResultManager.isClear = true;
            SceneManager.LoadScene("Result");
        }*/
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE : " + score;
        }
    }
}