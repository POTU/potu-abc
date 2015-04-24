using UnityEngine;
using System.Collections.Generic;

namespace Jalomieli.Extensions
{
	public static class DestructionExtensions
	{
		/// <summary>
		/// Destroys all children of the game object's transform.
		/// </summary>
		public static void DestroyChildren(this GameObject parent)
		{
			parent.transform.DestroyChildren();
		}
		
		/// <summary>
		/// Destroys all children of the mono behaviour's transform.
		/// </summary>
		public static void DestroyChildren(this MonoBehaviour parent)
		{
			parent.transform.DestroyChildren();
		}
		
		/// <summary>
		/// Destroys all children of the transform.
		/// </summary>
		public static void DestroyChildren(this Transform parent)
		{
			var children = new List<GameObject>();
			foreach (Transform child1 in parent)
			{
				children.Add(child1.gameObject);
			}
			foreach (GameObject child2 in children)
			{
				GameObject.Destroy(child2);
			}
		}
	}
}
