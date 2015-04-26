using UnityEngine;
using UnityEngine.UI;
using Jalomieli.Storage;

public class ShowHighscore : MonoBehaviour 
{
	void OnEnable()
	{
		var score = 0;
		Highscore hs;
		if (JsonStorage.TryLoad("highscore.json", out hs))
		{
			score = hs.Score;
		}
		var sprites = Resources.LoadAll<Sprite>("Sprites/Alphabet1");
		var findName = "aakkoset_" + score.ToString();
		foreach (var sprite in sprites)
		{
			if (sprite.name == findName)
			{
				GetComponent<Image>().sprite = sprite;
				break;
			}
		}
	}
}
