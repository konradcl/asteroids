public sealed class RootSystem : Feature  
{
	public RootSystem(Contexts contexts) 
	{
		Add(new HelloWorldSystem(contexts));
	}	
}