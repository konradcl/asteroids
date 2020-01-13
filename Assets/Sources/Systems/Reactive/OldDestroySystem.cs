using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class OldDestroySystem : ReactiveSystem<GameEntity> 
{
	public OldDestroySystem (Contexts contexts) : base(contexts.game) 
	{
			
   }
		
	// Specifies the component trigger that will invoke Execute.	
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.Destroyed);
	}
	
	// Verifies that entity has components required by Execute.
	protected override bool Filter(GameEntity entity) 
	{ 
		return entity.isDestroyed;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			if (e.hasView)
			{
				var view = e.view.value;
				view.Unlink();
				GameObject.Destroy(view);
			}
			e.Destroy();
		}
	}
}