using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		Application.LoadLevel("GameplayScreen");
	}
}
