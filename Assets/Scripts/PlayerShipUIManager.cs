using UnityEngine;
using UnityEngine.UI;

public class PlayerShipUIManager : MonoBehaviour
{
    private const int COLOR_HEALTH_HIGH = 70;
    private const int COLOR_HEALTH_MEDIUM = 40;
    private const int COLOR_HEALTH_LOW = 20;

    public Text ScoreText;
    public Text HealthText;
    public Text AmmunitionText;

    private PlayerView player;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = new ScoreManager();
    }

    private void FixedUpdate()
    {
        HealthColorManagement();
    }
    private void Update()
    {
        //HealthText.text = "Health: " + player.Health.ToString();
        //ScoreText.text = "Score: " + scoreManager.score.ToString();
        //if (!player.IsReloading)
        //{
        //    AmmunitionText.text = "Ammunition: " + player.Ammunition.ToString();
        //}
        //else
        //{
        //    AmmunitionText.text = "Recharge...";
        //}
    }
    private void HealthColorManagement()
    {
        //if (player.Health > COLOR_HEALTH_HIGH)
        //{
        //    HealthText.material.color = Color.green;
        //}
        //
        //if (player.Health <= COLOR_HEALTH_HIGH)
        //{
        //    HealthText.material.color = Color.cyan;
        //}
        //
        //if (player.Health <= COLOR_HEALTH_MEDIUM)
        //{
        //    HealthText.material.color = Color.yellow;
        //}
        //
        //if (player.Health <= COLOR_HEALTH_LOW)
        //{
        //    HealthText.material.color = Color.red;
        //}
    }
}
