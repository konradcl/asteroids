using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AddSpawnPositionToAsteroidSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext game;
	
	public AddSpawnPositionToAsteroidSystem (Contexts contexts) : base(contexts.game)
	{
		game = contexts.game;
	}
		
	// Specifies the component trigger that will invoke Execute.	
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.Asteroid);
	}
	
	// Verifies that entity has components required by Execute.
	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAsteroid;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			if (!e.hasSpawnPosition)
				e.AddSpawnPosition(
					new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f)
				);
		}
	}
}