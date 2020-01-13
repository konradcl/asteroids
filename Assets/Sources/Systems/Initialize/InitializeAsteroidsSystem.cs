using Entitas;

public sealed class InitializeAsteroidsSystem : IInitializeSystem
{
	readonly GameContext game;

	public InitializeAsteroidsSystem(Contexts contexts)
	{
		game = contexts.game;
	}

	// Initialize the components of an entity.
	public void Initialize()
	{
		for (int i = 0; i < 4; i++)
		{
			var e = game.CreateEntity();
			e.AddAsteroid(4);
		}
	}
}