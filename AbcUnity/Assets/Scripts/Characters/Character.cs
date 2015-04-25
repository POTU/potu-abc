using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour 
{
	public int powerLevel;
	public int GetPowerLevel()
	{
		return powerLevel;
	}
	public void IncreasePowerLevelBy(int amount)
	{
		powerLevel += amount;
		ExecuteEvents.Execute<ICharacterChangeHandler>(
			this.gameObject, 
			null, 
			(x, y) => x.OnPowerLevelChange(this)
		);
	}
}
