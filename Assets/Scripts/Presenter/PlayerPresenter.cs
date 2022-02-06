using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    public Action OnPlayerShooting;

    private PlayerModel playerModel;
    private PlayerView playerView;
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
    private void PlayerDamageTaken(IDamage damage)
    {
        playerModel.DamageTake(damage.Damage);
    }

    private void PlayerDead()
    {
        playerView.Dead();
    }
    public void PlayerShooting()
    {
        OnPlayerShooting?.Invoke();
    }
}
