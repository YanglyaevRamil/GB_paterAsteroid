using UnityEngine;

public class SpaceShipDataFactory
{
    private SpaceShipData[] spaceShipDatas;
    private GameObject[] spaceShipGameObjekts;

    public SpaceShipDataFactory()
    {
        spaceShipDatas = Resources.LoadAll<SpaceShipData>("ScriptableObject/SpaceShip");
        spaceShipGameObjekts = Resources.LoadAll<GameObject>("PrefabsAsset/SpaceShip");
    }
    public SpaceShipData InstantiateSpaceShip(SpaceShipType spaceShipType)
    {
        switch (spaceShipType)
        {
            case SpaceShipType.DefaultSpaceShip :
                return Instantiate(0);

            default :
                return Instantiate(0);
        }
    }
    private SpaceShipData Instantiate(int index)
    {
        var spaceShipData = Object.Instantiate(spaceShipDatas[index]);

        spaceShipData.SpaceShipGameObject = Object.Instantiate(spaceShipGameObjekts[index]);

        return spaceShipData;
    }
}
