﻿using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Extensions;

public class PlayerEatsLowerLevels : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other) 
	{
		var enemy = other.gameObject.GetComponent<Character>();
		if (enemy != null) 
		{
			var player = this.gameObject.DemandComponent<Character>();

			if (player.PowerLevel >= enemy.PowerLevel || enemy.PowerLevel == PowerUp.PowerUpLevel || PlayerController.GodMode)
			{
				ExecuteEvents.Execute<IDeathHandler>(
					enemy.gameObject, 
					null, 
					(x, y) => x.OnDeath()
				);
				player.IncreasePowerLevelBy(1);

                if(PlayerController.GodMode)
                {
                    PlayerController.GodModeKills++;
                }

                if (enemy.PowerUp != null)
                {
                    var playerController = this.gameObject.GetComponent<PlayerController>();
   
                    PlayerController.ActivePowerUps.Add(enemy.PowerUp);
                    enemy.PowerUp.StartEffect();
                    AudioSystem.Get().PlayPowerUp(enemy.PowerUp.id);
                }
                else
                {
                    AudioSystem.Get().PlayEnemyDeath(enemy.GetComponent<Character>().PowerLevel);
                }
				
				var go = Resources.Load<GameObject>("Particle Effects/SmokeBuff");
				go.Create(enemy.gameObject.transform.position, Quaternion.identity);


			    var maxPowerLevel = 25;
			    if (player.PowerLevel >= maxPowerLevel)
			    {
                    ExecuteEvents.Execute<IDeathHandler>(
                        player.gameObject,
                        null,
                        (x, y) => x.OnDeath()
                    );
			    }
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
