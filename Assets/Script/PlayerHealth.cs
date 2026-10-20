using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour 
{
    public int hp = 100;
    public int maxHP = 100;
    public GameObject gameOverText;
    public TextMeshProUGUI hpText; 
    public RectTransform hpBarFill; 
    private float maxBarWidth;
    void Start()
    { if (hpBarFill != null) 
        { maxBarWidth = hpBarFill.sizeDelta.x;
        }
        UpdateHPUI();
    }
    public void TakeDamage(int damage)
    { hp -= damage; hp = Mathf.Clamp(hp, 0, maxHP);
        UpdateHPUI();
        Debug.Log("プレイヤーHP：" + hp); 
        if (hp == 0) 
        {
            Debug.Log("ゲームオーバー！");

            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
            ResultManager.isClear = false;
            SceneManager.LoadScene("Result");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    } 
    void UpdateHPUI() 
    { 
        if (hpText != null)
        { 
            hpText.text = "HP:" + hp + "/" + maxHP;
        } 
        if (hpBarFill != null && maxHP > 0)
        { 
            float ratio = (float)hp / maxHP;
            hpBarFill.sizeDelta = new Vector2(maxBarWidth * ratio, hpBarFill.sizeDelta.y); 
        } 
    }
}