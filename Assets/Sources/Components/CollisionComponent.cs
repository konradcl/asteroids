using UnityEngine;
using Entitas;

[Game]
public sealed class CollisionComponent : IComponent
{
   public GameObject first;
   public GameObject second;
}
