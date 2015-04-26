using UnityEngine;
using Jalomieli.Extensions;

public class EnemyDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		Destroy(gameObject);
	}
}
