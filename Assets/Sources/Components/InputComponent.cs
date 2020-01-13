using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class InputComponent : IComponent
{
	public Vector3 value;
}