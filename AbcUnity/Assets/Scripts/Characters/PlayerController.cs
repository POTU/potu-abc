using UnityEngine;
using Jalomieli.Extensions;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D playerRigidbody2D;
	void Awake() 
	{
		playerRigidbody2D = this.gameObject.DemandComponent<Rigidbody2D>();
	}
	public void MoveUpAction()
	{
		playerRigidbody2D.AddForce(GetUpForce());
	}
	public void MoveRightAction()
	{
		playerRigidbody2D.AddForce(GetRightForce());
		playerRigidbody2D.AddTorque(-10f);
	}
	private Vector2 GetUpForce() 
	{
		return new Vector2(0, 500f);	
	}
	private Vector2 GetRightForce() 
	{
		return new Vector2(200f, 0);
	}
}
