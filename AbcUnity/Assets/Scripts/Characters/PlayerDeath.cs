using UnityEngine;
using System.Linq;

public class PlayerDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		var go = GameObject.FindGameObjectsWithTag("MainUIRoot").FirstOrDefault();
		var master = go.GetComponent<SubUIMaster>();
		master.ShowEndScreenSubUI();
	}
}
