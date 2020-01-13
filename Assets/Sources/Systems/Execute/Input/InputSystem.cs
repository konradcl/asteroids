using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem
{
   readonly Contexts contexts;

   public InputSystem(Contexts contexts)
   {
      this.contexts = contexts;
   }

   public void Execute()
   {
      var xInput = Input.GetAxisRaw("Horizontal");
      var yInput = Input.GetAxisRaw("Vertical");
      contexts.game.ReplaceInput(new Vector3(xInput, yInput, 0f));
   }
}
