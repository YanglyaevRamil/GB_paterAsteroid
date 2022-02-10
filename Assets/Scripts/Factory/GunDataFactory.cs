using UnityEngine;

public class GunDataFactory
{
    private GunData[] gunDatas;

    public GunDataFactory()
    {
        gunDatas = Resources.LoadAll<GunData>("ScriptableObject/Gun");
    }

    public GunData InstantiateGun(GunType gunType)
    {
        switch (gunType)
        {
            case GunType.DefaultGun:
                return Instantiate(0);

            default:
                return Instantiate(0);
        }
    }

    private GunData Instantiate(int index)
    {
        var gunData = Object.Instantiate(gunDatas[index]);
        return gunData;
    }
}
