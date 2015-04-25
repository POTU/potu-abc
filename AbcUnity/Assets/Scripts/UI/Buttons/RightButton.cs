using UnityEngine;
using Jalomieli.Extensions;

public class RightButton : MonoBehaviour 
{
	public void PlayerRightAction()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		player.DemandComponent<PlayerController>().MoveRightAction();
	}
}
