using UnityEngine.EventSystems;

public interface ICharacterChangeHandler : IEventSystemHandler 
{
	void OnPowerLevelChange(Character character);
}
