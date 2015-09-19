using UnityEngine;
using System.Collections;

public class GodmodePU : PowerUp {

    public GodmodePU(string name, float duration, int commonness, int id) : base( name, duration, commonness, id) { }
    
    public override void StartEffect()
    {
        timer = 0.0f;
        Debug.Log("GODMODE++");
        PlayerController.GodMode = true;
    }

    public override void EndEffect(PlayerController targetObject)
    {
        Debug.Log("GODMODE--");
        if (targetObject.spriteRenderer == null)
        {
            targetObject.spriteRenderer = targetObject.GetComponentInChildren<SpriteRenderer>();
        }
        Color newColor = new Color(1f, 1f, 1f, 1.0f);
        targetObject.spriteRenderer.color = newColor;
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
        base.Update(targetObject);
    }
}
