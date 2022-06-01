public class BulletSpawnerPresenter
{
    private BulletSpawnerModel _bulletSpawnerModel;
    private BulletSpawnerView _bulletSpawnerView;
    public BulletSpawnerPresenter(BulletSpawnerModel bulletSpawnerModel, BulletSpawnerView bulletSpawnerView)
    {
        _bulletSpawnerModel = bulletSpawnerModel;
        _bulletSpawnerView = bulletSpawnerView;
    }

    ~BulletSpawnerPresenter()
    {
        
    }
}
