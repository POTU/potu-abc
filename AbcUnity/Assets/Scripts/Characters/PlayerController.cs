using UnityEngine;
using Jalomieli.Extensions;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    public Sprite Level1Sprite;
    public Sprite Level2Sprite;
    public Sprite Level3Sprite;

    public Color Level1Color;
    public Color Level2Color;
    public Color Level3Color;

    public static PlayerController thisController;

    public List<PowerUp> ActivePowerUps;

    public static bool GodMode;
    public static int GodModeKills;

    public SpriteRenderer spriteRenderer;

    public Color originalColor;

	private Rigidbody2D playerRigidbody2D;
	void Awake() 
	{
        ActivePowerUps = new List<PowerUp>();
        GodModeKills = 0;
		playerRigidbody2D = this.gameObject.DemandComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        thisController = this;
	}

    public void SetSprite(int LoadedLevel)
    {
        switch (LoadedLevel)
        {
            case 1:
                spriteRenderer.sprite = Level1Sprite;
                originalColor = Level1Color;
                break;

            case 2:
                spriteRenderer.sprite = Level2Sprite;
                originalColor = Level2Color;
                break;

            case 3:
                spriteRenderer.sprite = Level3Sprite;
                originalColor = Level3Color;
                break;
        }

        spriteRenderer.color = originalColor;
    }

    void Update()
    {
        for (int i = 0; i < ActivePowerUps.Count; i++)
        {
            ActivePowerUps[i].Update(this);
        }

        if(spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.color = originalColor;
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
