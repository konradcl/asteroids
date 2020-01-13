using Entitas;
using UnityEngine;

public sealed class InitializePlayerSystem : IInitializeSystem  
{
	readonly Contexts contexts;

	public InitializePlayerSystem(Contexts contexts) 
	{
		this.contexts = contexts;
	}

	// Initialize the components of an entity.
	public void Initialize()
	{
		var e = contexts.game.CreateEntity();
		e.isPlayer = true;
		e.AddResource(contexts.game.gameSetup.value.playerPrefab);
		e.AddSpawnPosition(Vector3.zero);
		e.AddVelocity(Vector3.zero);
	}		
}