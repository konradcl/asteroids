public sealed class ExecuteSystems : Feature  
{
	public ExecuteSystems(Contexts contexts) 
	{
		Add(new InputSystem(contexts));
		Add(new ShootSystem(contexts));
		Add(new RotatePlayerSystem(contexts));
		Add(new ChangePlayerVelocitySystem(contexts));
		
		Add(new MoveSystem(contexts));
	}	
}