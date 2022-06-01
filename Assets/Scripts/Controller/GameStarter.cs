using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Data data;
    private Controllers controllers;

    private void Start()
    {
        controllers = new Controllers();
        new GameInitialization(controllers, data);
        controllers.Initialization();
    }
    
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        controllers.Execute(deltaTime);
    }

    private void LateUpdate()
    {
        var deltaTime = Time.deltaTime;
        controllers.LateExecute(deltaTime);
    }

    private void FixedUpdate()
    {
        controllers.FixedExecute();
    }

    private void OnDestroy()
    {
        controllers.Cleanup();
    }
}

