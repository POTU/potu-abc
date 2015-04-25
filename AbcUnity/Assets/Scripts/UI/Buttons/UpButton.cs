using UnityEngine;
using Jalomieli.Extensions;

public class UpButton : MonoBehaviour 
{
	public void PlayerUpAction()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		player.DemandComponent<PlayerController>().MoveUpAction();
	}
}
