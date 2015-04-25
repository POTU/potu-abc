﻿using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Extensions;

public class PlayerEatsKillsLowerLevels : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other) 
	{
		var enemy = other.gameObject.GetComponent<Character>();
		if (enemy != null) 
		{
			var player = this.gameObject.DemandComponent<Character>();
			if (player.GetPowerLevel() >= enemy.GetPowerLevel())
			{
				ExecuteEvents.Execute<IDeathHandler>(
					enemy.gameObject, 
					null, 
					(x, y) => x.OnDeath()
				);
				player.IncreasePowerLevelBy(1);
			}
			else 
			{
				ExecuteEvents.Execute<IDeathHandler>(
					player.gameObject, 
					null, 
					(x, y) => x.OnDeath()
				);
			}
		}
	}
}