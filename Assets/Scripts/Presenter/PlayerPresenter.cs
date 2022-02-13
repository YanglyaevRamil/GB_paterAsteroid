using System;
using UnityEngine;

public class PlayerPresenter
{
    public Action<int> OnPlayerShooting;
    public Action<int> OnDamageTaken;
    public Action<int> OnReloadGun;

    private PlayerModel playerModel;
    private PlayerView playerView;

    private SpaceSpipPresenter _spaceSpipPresenter;
    private GunPresenter _gunPresenter;
    private UserInputPresenter _userInputPresenter;

    public PlayerPresenter(SpaceSpipPresenter spaceSpipPresenter, GunPresenter gunPresenter, UserInputPresenter userInputPresenter)
    {
        _spaceSpipPresenter = spaceSpipPresenter;
        _gunPresenter = gunPresenter;
        _userInputPresenter = userInputPresenter;
    }

    public PlayerPresenter(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;

        playerView.OnKeyDownButtonShooting += KeyDownButtonShooting;
        playerView.OnKeyButtonRotation += KeyButtonRotation;
        playerView.OnKeyButtonMoving += KeyButtonMoving;
        playerView.OnDamageTaken += PlayerDamageTaken;
        playerView.OnGetDamage += GetDamage;

        playerModel.OnDead += PlayerDead;
        playerModel.OnShooting += PlayerShooting;
        playerModel.OnReloadGun += ReloadGun;
    }

    private void ReloadGun(int info)
    {
        OnReloadGun.Invoke(info);
    }

    private void KeyButtonRotation(Vector3 dir)
    {
        playerModel.Rotation(dir);
    }

    private void GetDamage()
    {
        playerView.GetDamage(playerModel.Damage);
    }

    private void KeyButtonMoving(Vector3 dir)
    {
        playerModel.Moving(dir);
    }

    private void KeyDownButtonShooting()
    {
        playerModel.Shooting();
    }
    private void PlayerDamageTaken(IDamageProvider damage)
    {
        playerModel.DamageTake(damage.Damage);
        OnDamageTaken.Invoke(playerModel.Health);
    }

    private void PlayerDead()
    {
        playerView.Dead();
    }
    public void PlayerShooting()
    {
        OnPlayerShooting?.Invoke(playerModel.Ammunition);
    }
}
