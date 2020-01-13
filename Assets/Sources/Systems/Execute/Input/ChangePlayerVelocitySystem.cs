using Entitas;
using UnityEngine;

public sealed class ChangePlayerVelocitySystem : IExecuteSystem
{
	readonly Contexts contexts;

	public ChangePlayerVelocitySystem(Contexts contexts)
	{
		this.contexts = contexts;
	}

	public void Execute()
	{
		var player = contexts.game.playerEntity;
		var velocityDirection = contexts.game.input.value.y;
		var vehicleDirection = player.view.value.transform.up;
		var movementSpeed = contexts.game.gameSetup.value.playerMovementSpeed;

		player.ReplaceVelocity(velocityDirection * movementSpeed *
			Time.deltaTime * vehicleDirection);
	}
}