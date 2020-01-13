public sealed class RootSystem : Feature
{
	public RootSystem(Contexts contexts) 
	{
		Add(new InitializeSystems(contexts));
		Add(new ReactiveSystems(contexts));
		Add(new ExecuteSystems(contexts));
		Add(new DestroySystem(contexts));
	}	
}