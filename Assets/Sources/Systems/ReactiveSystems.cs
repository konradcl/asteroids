public sealed class ReactiveSystems : Feature  
{
	public ReactiveSystems(Contexts contexts) 
	{
		Add(new ReactiveAsteroidSystems(contexts));
		Add(new InstantiateViewSystem(contexts));
		Add(new RotateLaserSystem(contexts));
	}	
}