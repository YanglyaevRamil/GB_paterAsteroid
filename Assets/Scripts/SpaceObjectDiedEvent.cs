using System;
using System.Collections.Generic;

public class SpaceObjectDiedEvent
{
    private readonly List<Action<SpaceObject>> _callbacks = new List<Action<SpaceObject>>();

    public void Subscribe(Action<SpaceObject> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(SpaceObject obj)
    {
        foreach (Action<SpaceObject> callback in _callbacks)
            callback(obj);
    }
}
