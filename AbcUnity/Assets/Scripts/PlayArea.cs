using UnityEngine;
using UnityEngine.EventSystems;

public class PlayArea : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other) 
	{
		ExecuteEvents.Execute<IDeathHandler>(
			other.gameObject, 
			null, 
			(x, y) => x.OnDeath()
		);
	}
}
