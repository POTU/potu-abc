using UnityEngine;
using Jalomieli.Debug;

public class PlayArea : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Player")) 
		{
			Log.Info("Player exited the play area.");
			Application.LoadLevel("GameplayScreen");
		}
	}
}
