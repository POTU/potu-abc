using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour 
{
	[SerializeField]
	private int powerLevel = 0;
	public int PowerLevel {
		get { return powerLevel; }
		set 
		{ 
			powerLevel = value; 
			ExecuteEvents.Execute<ICharacterChangeHandler>(
				this.gameObject, 
				null, 
				(x, y) => x.OnPowerLevelChange(this)
			);
		}
	}

    public PowerUp PowerUp;

	public void IncreasePowerLevelBy(int amount)
	{
		PowerLevel += amount;
	}

    void Update()
    {
        if (PowerUp != null) PowerUp.Update();
    }
}
