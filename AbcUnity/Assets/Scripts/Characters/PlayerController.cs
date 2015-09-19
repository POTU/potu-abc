using UnityEngine;
using Jalomieli.Extensions;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    public List<PowerUp> ActivePowerUps;

    public static bool GodMode;

    public SpriteRenderer spriteRenderer;

	private Rigidbody2D playerRigidbody2D;
	void Awake() 
	{
        ActivePowerUps = new List<PowerUp>();
		playerRigidbody2D = this.gameObject.DemandComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}

    void Update()
    {
        for (int i = 0; i < ActivePowerUps.Count; i++)
        {
            ActivePowerUps[i].Update(this);
        }
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
