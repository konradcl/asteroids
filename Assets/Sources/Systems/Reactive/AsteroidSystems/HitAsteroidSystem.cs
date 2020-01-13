using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HitAsteroidSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts contexts;
	
	public HitAsteroidSystem (Contexts contexts) : base(contexts.game)
	{
		this.contexts = contexts;
	}
		
	// Specifies the component trigger that will invoke Execute.	
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.Collision);
	}
	
	// Verifies that entity has components required by Execute.
	protected override bool Filter(GameEntity entity) 
	{ 
		return entity.hasCollision;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			var first = e.collision.first;
			var second = e.collision.second;

			var firstEntity = contexts.game.GetEntitiesWithView(first).SingleEntity();
			var secondEntity = contexts.game.GetEntitiesWithView(second).SingleEntity();

			for (int i = 0; i < 2; i++)
			{
				var newEntity = contexts.game.CreateEntity();
				newEntity.AddAsteroid(secondEntity.asteroid.size - 1);
				
				newEntity.AddSpawnPosition(second.transform.position 
					+ new Vector3(
						Random.Range(-0.05f, 0.05f), 
						Random.Range(-0.05f, 0.05f), 
						0f
					)
				);
			}

			firstEntity.isDestroyed = true;
			secondEntity.isDestroyed = true;
		}
	}
}