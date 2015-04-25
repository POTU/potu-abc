using UnityEngine;
using Jalomieli.Extensions;

[RequireComponent(typeof(PlayerController))]
public class PlayerKeyboardInput : MonoBehaviour 
{
	private PlayerController controller;
	void Awake()
	{
		controller = this.gameObject.DemandComponent<PlayerController>();
	}
	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			controller.MoveUpAction();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			controller.MoveRightAction();
		}
	}
}
