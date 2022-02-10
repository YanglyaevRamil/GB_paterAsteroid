using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HealthText;
    public Text AmmunitionText;

    private int scoreCnt;
    private void Start()
    {
        SetHealthText(100);
        SetScoreText(0);
        SetAmmunitionText(20);
    }
    public void SetHealthText(int info)
    {
        HealthText.text = "Health: " + info.ToString();
        HealthColorManagement(info);
    }

    public void SetScoreText(int info)
    {
        scoreCnt += info;
        ScoreText.text = "Score: " + scoreCnt.ToString();
    }

    public void SetAmmunitionText(int info)
    {
        
        if (info == 0)
        {
            AmmunitionText.text = "Reloading...";
        }
        else
        {
            AmmunitionText.text = "Ammunition: " + info.ToString(); 
        }
        
    }

    private void HealthColorManagement(int info)
    {
        if (info > UIConst.COLOR_HEALTH_HIGH)
        {
            HealthText.material.color = Color.green;
        }
        
        if (info <= UIConst.COLOR_HEALTH_HIGH)
        {
            HealthText.material.color = Color.cyan;
        }
        
        if (info <= UIConst.COLOR_HEALTH_MEDIUM)
        {
            HealthText.material.color = Color.yellow;
        }
        
        if (info <= UIConst.COLOR_HEALTH_LOW)
        {
            HealthText.material.color = Color.red;
        }
    }
}
