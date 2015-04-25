using System.Collections.Generic;
using UnityEngine;
using Jalomieli.Extensions;

public class CharacterVisual : MonoBehaviour, ICharacterChangeHandler
{
    public static List<GameObject> ImageColliders = new List<GameObject>();
	public void OnPowerLevelChange(Character character) 
	{
        gameObject.DestroyChildren();
        ImageColliders[character.PowerLevel].CreateAsChild(gameObject);
	}
}
