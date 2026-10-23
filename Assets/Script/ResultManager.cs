using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultTitle;
    public TextMeshProUGUI finalScoreText;

    public static bool isClear = false;

    void Start()
    {
        if (isClear)
            resultTitle.text = "GAME CLEAR";
        else
            resultTitle.text = "GAME OVER";

        if (finalScoreText != null)
        {
            finalScoreText.text = "FINAL SCORE : " + GameManager.score;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}