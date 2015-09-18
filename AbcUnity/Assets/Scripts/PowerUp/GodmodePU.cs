using UnityEngine;
using System.Collections;

public class GodmodePU : PowerUp {

    public GodmodePU(string name, float duration, int commonness) : base( name, duration, commonness)
    {
        
    }
    
    public override void StartEffect()
    {
        Debug.Log("GODMODE++");
        PlayerController.GodMode = true;
    }

    public override void EndEffect()
    {
        Debug.Log("GODMODE--");
        PlayerController.GodMode = false;
    }
}
