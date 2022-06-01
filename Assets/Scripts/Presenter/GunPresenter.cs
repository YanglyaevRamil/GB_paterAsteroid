using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPresenter
{
    private GunView _gunView;
    private GunModel _gunModel;
    public GunPresenter(GunView gunView, GunModel gunModel)
    {
        _gunView = gunView;
        _gunModel = gunModel;
    }
}
