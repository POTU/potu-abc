using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Extensions;

public class PlayerEatsKillsLowerLevels : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other) 
	{
		var enemyPowerLevel = other.gameObject.GetComponent<PowerLevel>();
		if (enemyPowerLevel != null) 
		{
			var enemyLevel = enemyPowerLevel.GetPowerLevel();
			var playerPowerLevel = this.gameObject.DemandComponent<PowerLevel>();
			var playerLevel = playerPowerLevel.GetPowerLevel();
			if (playerLevel >= enemyLevel)
			{
				ExecuteEvents.Execute<IDeathHandler>(
					other.gameObject, 
					null, 
					(x, y) => x.OnDeath()
				);
				playerPowerLevel.IncreaseBy(1);
			}
			else 
			{
				ExecuteEvents.Execute<IDeathHandler>(
					this.gameObject, 
					null, 
					(x, y) => x.OnDeath()
				);
			}
		}
	}
}
