using UnityEngine;
using Jalomieli.Debug;
using Jalomieli.Storage;

public class ShowHighscore : MonoBehaviour 
{
	void OnEnable()
	{
		var score = 1;
		Highscore hs;
		if (BinaryStorage.TryLoad("highscore.dat", out hs))
		{
			score = hs.Score;
		}
		Log.Warning(score);
	}
}
