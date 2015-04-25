using System.Collections.Generic;
using UnityEngine;
using Jalomieli.Debug;
using Jalomieli.Extensions;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterVisual : MonoBehaviour, ICharacterChangeHandler
{
	void Start()
	{
		OnPowerLevelChange(gameObject.DemandComponent<Character>());
	}
	public void OnPowerLevelChange(Character character) 
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		var sprites = Resources.LoadAll<Sprite>("Sprites");
		var findName = "aakkoset_" + character.PowerLevel.ToString();
		var sprite = sprites.FirstOrDefault((s) => s.name == findName);
		Assert.NotNull(sprite);
		spriteRenderer.sprite = sprite;
	}
}
