using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp  {  
    
    private static List<PowerUp> list = new List<PowerUp>();

    private static int totalCommonness;

    public string name;

    private float duration;

    private float timer = 0f;

    private int commonness;

    public PowerUp(){ }
    
    public PowerUp(string name, float duration, int commonness)
    {
        this.commonness = commonness;
        totalCommonness += commonness;

        this.name = name;
        this.duration = duration;
        this.commonness = commonness;

        list.Add(this);
    }

    static PowerUp()
    {
        PowerUp pu = new PowerUp("Wrap", 10.0f, 1);
        pu.name = "wrap";

        GodmodePU GodMode = new GodmodePU("GodMode", 20f, 2);
        GodMode.name = "GodMode";
    }

    public static PowerUp GetRandom()
    {
        int randomNumber = Random.Range(0, totalCommonness);

        PowerUp selectedPowerUp = null;
        foreach (PowerUp powerUp in list)
        {
            if (randomNumber <= powerUp.commonness)
            {
                selectedPowerUp = powerUp;
                break;
            }

            randomNumber = randomNumber - powerUp.commonness;
        }

        return selectedPowerUp;
    }

    public virtual void Update(PlayerController targetObject)
    {
        if (duration > timer)
        {
            timer += Time.deltaTime;
            return;
        }

        EndEffect();
        targetObject.ActivePowerUps.Remove(this);
    }

    public virtual void StartEffect()
    {
        Debug.Log("Base");
    }

    public virtual void EndEffect()
    {

    }
}
