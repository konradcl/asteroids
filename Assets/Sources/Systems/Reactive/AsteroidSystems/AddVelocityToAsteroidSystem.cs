using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Entitas;

public class AddVelocityToAsteroidSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext game;
	
	public AddVelocityToAsteroidSystem (Contexts contexts) : base(contexts.game)
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
		var speed = game.gameSetup.value.asteroidSpeed;
			
		foreach (var e in entities) 
		{
			var randomAngle = Random.Range(0f, (float) Math.PI);
			
			e.AddVelocity(new Vector3(
				speed * Mathf.Cos(randomAngle), 
				speed * Mathf.Sin(randomAngle), 
				0
			));
		}
	}
}