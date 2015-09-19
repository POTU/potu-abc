using UnityEngine;
using System.Collections;

public class FlipAxisPU : PowerUp {

	public FlipAxisPU(string name, float duration, int commonness, int id) : base( name, duration, commonness, id) { }
    
    public override void StartEffect()
    {
        timer = 0.0f;
        EnemySpawn.FlipAxis = true;
        Debug.Log("FLIPAXIS++");
    }

    public override void EndEffect(PlayerController targetObject)
    {
        base.EndEffect(targetObject);
        EnemySpawn.FlipAxis = false;
        Debug.Log("FLIPAXIS--");
    }
}
