using UnityEngine;
using Jalomieli.Extensions;
using DG.Tweening;

public class CharacterFadesIn : MonoBehaviour 
{
	void Start () 
	{
		var renderer = this.gameObject.DemandComponentInChildren<SpriteRenderer>();
		var o = renderer.color;
		renderer.color = new Color(o.r, o.g, o.b, 0f);
		renderer.DOColor(o, 2f);
	}
}
