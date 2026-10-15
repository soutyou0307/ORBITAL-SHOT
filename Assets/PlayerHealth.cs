using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour 
{
    public int hp = 100;
    public int maxHP = 100;
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
        Debug.Log("プレイヤーHP：" + hp); if (hp == 0) 
        {
            Debug.Log("ゲームオーバー！");
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