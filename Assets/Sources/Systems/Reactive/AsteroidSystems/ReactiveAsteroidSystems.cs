using Entitas;

public sealed class ReactiveAsteroidSystems : Feature  
{
	public ReactiveAsteroidSystems(Contexts contexts) 
	{
		Add(new AddResourceToAsteroidSystem(contexts));
		Add(new AddSpawnPositionToAsteroidSystem(contexts));
		Add(new AddVelocityToAsteroidSystem(contexts));
		Add(new HitAsteroidSystem(contexts));
	}	
}