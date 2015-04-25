using UnityEngine;
using Jalomieli.Extensions;

public class EnemyDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		var go = Resources.Load<GameObject>("Particle Effects/SmokeBuff");
		go.Create(gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
