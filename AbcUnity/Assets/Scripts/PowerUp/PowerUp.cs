using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp  {

    public static int PowerUpLevel = 26;
    private static List<PowerUp> list = new List<PowerUp>();

    public int id;

    private static int totalCommonness;

    public string name;

    private float duration;

    protected float timer = 0f;

    private int commonness;

    public PowerUp(){ }
    
    public PowerUp(string name, float duration, int commonness, int id)
    {
        this.commonness = commonness;
        totalCommonness += commonness;

        this.name = name;
        this.duration = duration;
        this.commonness = commonness;

        this.id = id;

        list.Add(this);
    }

    static PowerUp()
    {
        GodmodePU GodMode = new GodmodePU("GodMode", 5f, 2, 0);
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

        EndEffect(targetObject);
        targetObject.ActivePowerUps.Remove(this);
    }

    public virtual void StartEffect()
    {
        timer = 0.0f;
        Debug.Log("Base");
    }

    public virtual void EndEffect(PlayerController targetObject)
    {

    }
}
