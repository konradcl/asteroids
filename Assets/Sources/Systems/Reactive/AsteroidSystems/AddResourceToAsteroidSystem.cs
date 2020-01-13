using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AddResourceToAsteroidSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext game;
	
	public AddResourceToAsteroidSystem (Contexts contexts) : base(contexts.game)
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
			int index = Random.Range(0, 1);
			int size = e.asteroid.size;
			var setup = game.gameSetup.value;

			switch (size)
			{
				case 1:
					e.AddResource(setup.tinyAsteroids[index]);
					break;
				case 2:
					e.AddResource(setup.smallAsteroids[index]);
					break;
				case 3:
					e.AddResource(setup.mediumAsteroids[index]);
					break;
				case 4:
					e.AddResource(setup.bigAsteroids[index]);
					break;
				default:
					e.isDestroyed = true;
					break;
			}
		}
	}
}