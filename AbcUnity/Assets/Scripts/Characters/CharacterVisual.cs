using System.Collections.Generic;
using UnityEngine;
using Jalomieli.Debug;
using Jalomieli.Extensions;
using System.Linq;

public class CharacterVisual : MonoBehaviour, ICharacterChangeHandler
{

    public static List<GameObject> ImageColliders = new List<GameObject>();

	void Start()
	{
		//OnPowerLevelChange(gameObject.DemandComponent<Character>());
	}

	public void OnPowerLevelChange(Character character) 
	{
        gameObject.DestroyChildren();
        ImageColliders[character.PowerLevel].CreateAsChild(gameObject);

        //var spriteRenderer = GetComponent<SpriteRenderer>();
        //var sprites = Resources.LoadAll<Sprite>("Sprites/Alphabet1");
        //var findName = "aakkoset_" + character.PowerLevel.ToString();
        //var sprite = sprites.FirstOrDefault((s) => s.name == findName);
		//Assert.NotNull(sprite);
		//spriteRenderer.sprite = sprite;
	}
}
