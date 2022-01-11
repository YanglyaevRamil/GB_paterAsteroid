
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipUIManager : MonoBehaviour
{
    private const int COLOR_HEALTH_HIGH = 70;
    private const int COLOR_HEALTH_MEDIUM = 40;
    private const int COLOR_HEALTH_LOW = 20;

    public GameObject ship;
    public GameObject Manager;

    public Text ScoreText;
    public Text HealthText;
    public Text AmmunitionText;

    private SpaceShip spaceShip;
    private ScoreManager scoreManager;

    private void Start()
    {
        spaceShip = ship.GetComponent<SpaceShip>();
        scoreManager = Manager.GetComponent<ScoreManager>();
    }

    private void FixedUpdate()
    {
        HealthColorManagement();
    }
    private void Update()
    {
        HealthText.text = "Health: " + spaceShip.health.ToString();
        ScoreText.text = "Score: " + scoreManager.score.ToString();
        if (!spaceShip.isReloading)
        {
            AmmunitionText.text = "Ammunition: " + spaceShip.ammunition.ToString();
        }
        else
        {
            AmmunitionText.text = "Recharge...";
        }

    }
    private void HealthColorManagement()
    {
        if (spaceShip.health > COLOR_HEALTH_HIGH)
        {
            HealthText.material.color = Color.green;
        }

        if (spaceShip.health <= COLOR_HEALTH_HIGH)
        {
            HealthText.material.color = Color.cyan;
        }

        if (spaceShip.health <= COLOR_HEALTH_MEDIUM)
        {
            HealthText.material.color = Color.yellow;
        }

        if (spaceShip.health <= COLOR_HEALTH_LOW)
        {
            HealthText.material.color = Color.red;
        }
    }
}
