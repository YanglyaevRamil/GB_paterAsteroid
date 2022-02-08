using UnityEngine;
using UnityEngine.UI;

public class GameMeneger : MonoBehaviour
{
    private PlayerUIManager playerUI;
    private SoundController soundManager;

    void Start()
    {
        var playerManagerGameObject = new GameObject("PlayerManager");
        playerManagerGameObject.transform.SetParent(transform);
        var playerManager = playerManagerGameObject?.AddComponent<PlayerManager>();
        playerManager.OnPlayerDamageTaken += PlayerDamageTaken;
        playerManager.OnPlayerShooting += PlayerShooting;
        playerManager.OnPlayerReloadGun += PlayerReloadGun;

        var asteroidManagerGameObject = new GameObject("AsteroidManager");
        asteroidManagerGameObject.transform.SetParent(transform);
        var asteroidManager = asteroidManagerGameObject?.AddComponent<AsteroidManager>();
        asteroidManager.target = playerManager.PlayerObject.transform;
        asteroidManager.OnDeadAsteroid += DeadAsteroid;

        var planets = Resources.LoadAll<GameObject>("PrefabsAsset/Planet");
        for (int i = 0; i < planets.Length; i++)
        {
            var planet = Instantiate(planets[i]);
            var targetTransform = planet?.GetComponent<ObjectTurnByPlayer>();
            targetTransform.targetTransform = playerManager.PlayerObject.transform;
        }

        var soundManagerGameObject = new GameObject("SoundManager");
        soundManagerGameObject.transform.SetParent(transform);
        soundManager = soundManagerGameObject?.AddComponent<SoundController>();
        soundManager.MusicVolumeChanged();
        soundManager.SoundsVolumeChanged();
        soundManager.PlayMusic(MusicEnum.BattleMusic);

        var playerUIGameObject = Instantiate(Resources.Load<GameObject>("PrefabsAsset/UI/CanvasUI"));
        playerUI = playerUIGameObject?.GetComponent<PlayerUIManager>();
        var btn = playerUIGameObject.transform?.Find("PauseMenu/ContinueButton")?.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClick);
        btn = playerUIGameObject.transform?.Find("PauseMenu/MenuButton")?.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        soundManager.PlaySound(SoundsEnum.ButtonClick);
    }

    private void PlayerReloadGun(int info)
    {
        playerUI.SetAmmunitionText(info);
    }

    private void PlayerShooting(int info)
    {
        playerUI.SetAmmunitionText(info);
        soundManager.PlaySound(SoundsEnum.PlayerShot);
    }

    private void PlayerDamageTaken(int info)
    {
        playerUI.SetHealthText(info);
        soundManager.PlaySound(SoundsEnum.PlayerHit);
    }

    private void DeadAsteroid(AsteroidData asteroidData)
    {
        playerUI.SetScoreText(asteroidData.PricePoints);
        soundManager.PlaySound(SoundsEnum.AsteroidDead);
    }
}
