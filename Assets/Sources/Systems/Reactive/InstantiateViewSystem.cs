using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
	private Contexts contexts;
	
	public InstantiateViewSystem (Contexts contexts) : base(contexts.game)
	{
		this.contexts = contexts;
	}
		
	// Specifies the component trigger that will invoke Execute.	
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.Resource);
	}
	
	// Verifies that entity has components required by Execute.
	protected override bool Filter(GameEntity entity)
	{
		return entity.hasResource;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			var gameObject = GameObject.Instantiate(e.resource.prefab);
			e.AddView(gameObject);
			gameObject.Link(e); // MAY BE WRONG (creates EntityLink in inspector)

			if (e.hasSpawnPosition)
			{
				gameObject.transform.position = e.spawnPosition.value;
			}
		}
	}
}