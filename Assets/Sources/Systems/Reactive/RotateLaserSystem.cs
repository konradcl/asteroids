using Entitas;
using System.Collections.Generic;

public class RotateLaserSystem : ReactiveSystem<GameEntity> 
{
	public RotateLaserSystem (Contexts contexts) : base(contexts.game) 
	{
			
   }
		
	// Specifies the component trigger that will invoke Execute.	
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher
			.AllOf(GameMatcher.Laser, GameMatcher.View, GameMatcher.Velocity)
		);
	}
	
	// Verifies that entity has components required by Execute.
	protected override bool Filter(GameEntity e)
	{
		return e.isLaser && e.hasView && e.hasVelocity;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			var transform = e.view.value.transform;
			var velocity = e.velocity.value;
			transform.up = velocity.normalized;
		}
	}
}