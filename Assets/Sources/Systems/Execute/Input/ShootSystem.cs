using Entitas;
using UnityEngine;

public sealed class ShootSystem : IExecuteSystem
{
   readonly GameContext game;

   public ShootSystem(Contexts contexts)
   {
      game = contexts.game;
   }

   public void Execute()
   {
      if (Input.GetButtonDown("Fire"))
      {
         var setup = game.gameSetup.value;
         var transform = game.playerEntity.view.value.transform;
         
         var e = game.CreateEntity();
         e.isLaser = true;
         e.AddResource(setup.laser);
         e.AddSpawnPosition(transform.position);
         e.AddVelocity(transform.up * setup.laserSpeed);
      }
   }
}
