using UnityEngine;
using System.Collections;

public class GodmodePU : PowerUp {

    public GodmodePU(string name, float duration, int commonness, int id) : base( name, duration, commonness, id) { }

    private int KillCount;
    
    public override void StartEffect()
    {
        timer = 0.0f;
        PlayerController.GodModeKills = 0;
        KillCount = 3;
        Debug.Log("GODMODE++");
        PlayerController.GodMode = true;
    }

    public override void EndEffect(PlayerController targetObject)
    {
        base.EndEffect(targetObject);

        Debug.Log("GODMODE--");

        if(targetObject.spriteRenderer == null)
        {
            targetObject.spriteRenderer = targetObject.GetComponentInChildren<SpriteRenderer>();
        }

        targetObject.spriteRenderer.color = targetObject.originalColor;
        PlayerController.GodMode = false;
    }

    public override void Update(PlayerController targetObject)
    {
        if (targetObject.spriteRenderer == null)
        {
            targetObject.spriteRenderer = targetObject.GetComponentInChildren<SpriteRenderer>();
        }
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        targetObject.spriteRenderer.color = newColor;
        
        if(PlayerController.GodModeKills >= KillCount)
        {
            PlayerController.ActivePowerUps.Remove(this);
            EndEffect(targetObject);
        }
    }
}
