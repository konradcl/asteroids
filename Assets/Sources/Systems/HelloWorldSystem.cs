using UnityEngine;
using Entitas;

public sealed class HelloWorldSystem : IInitializeSystem  
{
	readonly Contexts contexts;

	public HelloWorldSystem(Contexts contexts) 
	{
		this.contexts = contexts;
	}

	// Initialize the components of an entity.
	public void Initialize()
	{
		Debug.Log("Hello, World!");
	}		
}