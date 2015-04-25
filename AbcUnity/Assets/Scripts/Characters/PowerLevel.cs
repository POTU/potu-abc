using UnityEngine;

public class PowerLevel : MonoBehaviour 
{
	public int powerLevel;
	public int GetPowerLevel()
	{
		return powerLevel;
	}
	public void IncreaseBy(int amount)
	{
		powerLevel += amount;
	}
}
