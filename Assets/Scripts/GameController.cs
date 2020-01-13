using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameSetup gameSetup;
	private RootSystem system;

	void Start()
	{
		var contexts = Contexts.sharedInstance;
		system = new RootSystem(contexts);

		contexts.game.SetGameSetup(gameSetup);

		system.Initialize();
	}

	void Update()
	{
		system.Execute();
		system.Cleanup();
	}
}