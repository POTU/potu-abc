using UnityEngine;
using System.Linq;
using Jalomieli.Storage;

public class PlayerDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
		var score = gameObject.GetComponent<Character>().PowerLevel;
		Highscore hs;
		if (JsonStorage.TryLoad("highscore.json", out hs))
		{
			if (score > hs.Score) {
				hs.Score = score;
				JsonStorage.Save("highscore.json", hs);
			}
		}
		else 
		{
			hs = new Highscore();
			hs.Score = score;
			JsonStorage.Save("highscore.json", hs);
		}
	
		var go = GameObject.FindGameObjectsWithTag("MainUIRoot").FirstOrDefault();
		var master = go.GetComponent<SubUIMaster>();
		master.ShowEndScreenSubUI();
		
		AudioSystem.Get().PlayPlayerDeath();
		
		Destroy(gameObject);
	}
}
