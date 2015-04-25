using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		Destroy(gameObject);
	}
}
