using UnityEngine;
using Jalomieli.Extensions;
using Jalomieli.Debug;

[RequireComponent(typeof(Collider2D))]
public class OnCollisionKillWeaker : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.CompareTag("Player")) 
		{
			var playerLevel = other.gameObject.DemandComponent<PowerLevel>().GetPowerLevel();
			var enemyLevel = this.gameObject.DemandComponent<PowerLevel>().GetPowerLevel();
			if (playerLevel < enemyLevel)
			{
				Log.Info("Player died from touch.");
				Application.LoadLevel("GameplayScreen");
			}
			else 
			{
				Destroy(this.gameObject);
			}
		}
	}
}
