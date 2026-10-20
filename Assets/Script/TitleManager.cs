using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ƒQ[ƒ€‚ğI—¹‚µ‚Ü‚·");
    }
}