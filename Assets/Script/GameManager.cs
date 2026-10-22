using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int killCount = 0;
    public int clearKillCount = 10;

    private bool isGameEnded = false;

    void Start()
    {
        killCount = 0;
        isGameEnded = false;
        ResultManager.isClear = false;
    }

    public void AddKill()
    {
        if (isGameEnded) return;

        killCount++;
        Debug.Log("Œ‚”j”F" + killCount + "/" + clearKillCount);

        if (killCount >= clearKillCount)
        {
            isGameEnded = true;
            ResultManager.isClear = true;
            SceneManager.LoadScene("Result");
        }
    }

}