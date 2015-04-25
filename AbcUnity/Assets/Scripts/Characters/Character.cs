using UnityEngine;

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
	}
}
