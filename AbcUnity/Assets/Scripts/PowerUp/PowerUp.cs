using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp  {

    public static int PowerUpLevel = 26;
    private static List<PowerUp> list = new List<PowerUp>();

    private static int totalCommonness;

    private string name;

    private float duration;

    private float timer;

    private int commonness;
    
    public PowerUp(string name, float duration, int commonness)
    {
        this.commonness = commonness;
        totalCommonness += commonness;

        this.name = name;
        this.commonness = commonness;

        list.Add(this);
    }

    static PowerUp()
    {
        PowerUp pu = new PowerUp("Wrap", 10.0f, 1);
        pu.name = "wrap";
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

    public virtual void Update(GameObject targetObject)
    {
    }
}
