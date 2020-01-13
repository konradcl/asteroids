using Entitas;
using UnityEngine;

public sealed class MoveSystem : IExecuteSystem
{
   private readonly Contexts contexts;
   private readonly IGroup<GameEntity> acceleratingEntities;

   public MoveSystem(Contexts contexts)
   {
      this.contexts = contexts;
      acceleratingEntities = contexts.game.GetGroup(GameMatcher
         .AllOf(GameMatcher.Velocity, GameMatcher.View));
   }

   public void Execute()
   {
      foreach (var e in acceleratingEntities)
      {
         var transform = e.view.value.transform;
         transform.position += e.velocity.value * Time.deltaTime;
      }
   }
}
