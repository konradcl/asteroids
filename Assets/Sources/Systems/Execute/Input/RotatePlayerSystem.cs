using Entitas;
using UnityEngine;

public sealed class RotatePlayerSystem : IExecuteSystem
{
   readonly Contexts contexts;

   public RotatePlayerSystem(Contexts contexts)
   {
      this.contexts = contexts;
   }

   public void Execute()
   {
      var input = contexts.game.input.value.x;
      var playerTransform = contexts.game.playerEntity.view.value.transform;
      var playerRotation = playerTransform.rotation.eulerAngles;
      playerRotation.z -= input * contexts.game.gameSetup.value.rotationSpeed *
                          Time.deltaTime;
      playerTransform.rotation = Quaternion.Euler(playerRotation);
   }
}
