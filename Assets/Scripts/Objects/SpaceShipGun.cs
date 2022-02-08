using UnityEngine;

public class SpaceShipGun : ISpaceShipGun
{
    private const float TIMER_TICK = 100.0f; // 0.1 sec
    public int Ammunition { get { return ammunition; } set { ammunition = value; } }
    public float GunReloadingTime { get { return gunReloadingTime; } }

    private float gunReloadingTime;
    private int ammunition;
    private int ammunitionMax;
    private bool emptyAmmunition;
    private GameTimer gameTimer;

    public SpaceShipGun(int ammunition, float gunRecoilTime, float gunReloadingTime)
    {
        this.ammunition = ammunition;
        ammunitionMax = ammunition;
        emptyAmmunition = false;
        gameTimer = new GameTimer(TIMER_TICK, gunRecoilTime);

        this.gunReloadingTime = gunReloadingTime;
    }

    public bool Shot()
    {
        if (ammunition == 0)
        {
            return false;
        }
        else 
        {
            if (gameTimer.FlagStopWatch)
            {
                gameTimer.StartTimer();
                ammunition--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public void Reload()
    {
        ammunition = ammunitionMax;
    }
    public bool CheckGunAmunition()
    {
        return emptyAmmunition;
    }
}
