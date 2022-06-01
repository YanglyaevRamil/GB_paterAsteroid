using UnityEngine;

public class Shooting : IShoot
{
    public int Ammunition { get { return ammunition; } set { ammunition = value; } }
    public float GunReloadingTime { get { return gunReloadingTime; } }

    private float gunReloadingTime;
    private int ammunition; 
    private int ammunitionMax;
    private bool emptyAmmunition;
    private GameTimer gameTimer;

    public Shooting(int ammunition, float gunRecoilTime, float gunReloadingTime)
    {
        this.ammunition = ammunition;
        ammunitionMax = ammunition;
        emptyAmmunition = false;
        gameTimer = new GameTimer(GunConst.TIMER_TICK, gunRecoilTime);

        this.gunReloadingTime = gunReloadingTime;
    }

    public bool Shoot()
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
