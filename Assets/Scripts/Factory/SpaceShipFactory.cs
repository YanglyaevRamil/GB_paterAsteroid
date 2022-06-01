using UnityEngine;

public class SpaceShipFactory
{
    private SpaceShipData[] _spaceShipDatas;
    private GameObject[] _spaceShipGO;
    private UserInputModel _userInputModel;
    private GunModel _gunModel;

    public SpaceShipFactory(SpaceShipData[] spaceShipDatas, UserInputModel userInputModel, GunModel gunModel)
    {
        _spaceShipDatas = spaceShipDatas;
        _spaceShipGO = Resources.LoadAll<GameObject>(SpaceShipConst.PATH_GO);
        _userInputModel = userInputModel;
        _gunModel = gunModel;
    }

    public (SpaceShipModel spaceShipModel, SpaceShipView spaceShipView, SpaceShipPresenter spaceShipPresenter) GetSpaceShip(SpaceShipType spaceShipType)
    {
        var shipData = GetShipData(spaceShipType);

        return BildAsteroid(shipData);
    }

    private (SpaceShipModel spaceShipModel, SpaceShipView spaceShipView, SpaceShipPresenter spaceShipPresenter) BildAsteroid(SpaceShipData spaceShipData)
    {
        var spaceShipModel = new SpaceShipModel(spaceShipData);
        var spaceShipView = spaceShipData.SpaceShipGO?.GetComponent<SpaceShipView>();
        var spaceShipPresenter = new SpaceShipPresenter(spaceShipModel, spaceShipView);

        return (spaceShipModel, spaceShipView, spaceShipPresenter);
    }

    private SpaceShipData GetShipData(SpaceShipType spaceShipType)
    {
        return Instantiate((int)spaceShipType);
    }

    private SpaceShipData Instantiate(int index)
    {
        var spaceShipData = Object.Instantiate(_spaceShipDatas[index]);
        spaceShipData.SpaceShipGO = Object.Instantiate(_spaceShipGO[index]);
        spaceShipData.UserInputModel = _userInputModel;
        spaceShipData.GunModel = _gunModel;
        return spaceShipData;
    }
}
