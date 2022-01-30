using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;

        playerView.OnKeyDownButtonShooting += KeyDownButtonShooting;
        playerView.OnDamageTaken += PlayerDamageTaken;

        playerModel.OnDead += PlayerDead;
        playerModel.OnShooting += PlayerShooting;
        
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
    private void PlayerShooting()
    {
        throw new NotImplementedException();
    }

}
