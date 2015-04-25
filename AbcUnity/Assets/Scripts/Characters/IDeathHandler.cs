using UnityEngine.EventSystems;

public interface IDeathHandler : IEventSystemHandler 
{
	void OnDeath();
}
