using UnityEngine;
using System.Linq;
using Jalomieli.Storage;
using Jalomieli.Extensions;

public class PlayerDeath : MonoBehaviour, IDeathHandler
{
	public void OnDeath() 
	{
        EnemySpawn.FlipAxis = false;

        for (int i = 0; i < PlayerController.ActivePowerUps.Count; i++)
        {
            PlayerController.ActivePowerUps[i].EndEffect(PlayerController.thisController);
        }

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

        var go = Resources.Load<GameObject>("Particle Effects/SmokeBuff");
        go.Create(gameObject.transform.position, Quaternion.identity);
		
		AudioSystem.Get().PlayPlayerDeath();
        PlayArea.thisArea.ShowEnd();

        Destroy(gameObject);
	}
}
