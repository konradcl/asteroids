using UnityEngine;

public class EmitTriggerEntityBehavior : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D other)
	{
		var e = Contexts.sharedInstance.game.CreateEntity();
		e.AddCollision(gameObject, other.gameObject);
	}
}
