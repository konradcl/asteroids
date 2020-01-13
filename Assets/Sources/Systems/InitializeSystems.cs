using Entitas;

public sealed class InitializeSystems : Feature  
{
	public InitializeSystems(Contexts contexts) 
	{
		Add(new InitializePlayerSystem(contexts));
		Add(new InitializeAsteroidsSystem(contexts));
	}	
}