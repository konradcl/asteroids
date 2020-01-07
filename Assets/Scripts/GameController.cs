using UnityEngine;

public class GameController : MonoBehaviour
{
    private RootSystem _system;

    void Start()
    {
        var contexts = Contexts.sharedInstance;
        _system = new RootSystem(contexts);
        
        _system.Initialize();
    }

    void Update()
    {
        _system.Execute();
    }
}
