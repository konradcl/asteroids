using UnityEngine;
using Entitas;
using Entitas.Unity;

public sealed class DestroySystem : ICleanupSystem
{
	private readonly GameContext game;
	private readonly IGroup<GameEntity> group;

	public DestroySystem(Contexts contexts)
	{
		game = contexts.game;
		group = game.GetGroup(GameMatcher.Destroyed);
	}

	public void Cleanup()
	{
		foreach (var e in group.GetEntities())
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