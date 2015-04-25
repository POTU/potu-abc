using UnityEngine;

namespace Jalomieli.Extensions
{
	public static class InitializationExtensions
	{
		/// <summary>
		/// Create and return a copy from the provided game object, usually a prefab.
		/// </summary>
		public static GameObject Create(this GameObject original)
		{
			var go = (GameObject)Object.Instantiate(original);
			go.name = original.name;
			go.transform.parent = null;
			go.transform.localScale = Vector3.one;
			return go;
		}
		
		/// <summary>
		/// Create and return a copy from the provided game object with given position and rotation.
		/// </summary>
		public static GameObject Create(this GameObject original, Vector3 position, Quaternion rotation)
		{
			var go = (GameObject)Object.Instantiate(original, position, rotation);
			go.name = original.name;
			go.transform.parent = null;
			go.transform.localScale = Vector3.one;
			return go;
		}
		
		/// <summary>
		/// Create and return a copy from the provided game object as a child of the other provided game object.
		/// </summary>
		public static GameObject CreateAsChild(this GameObject original, GameObject parent)
		{
			return CreateAsChild(original, parent.transform);
		}
		
		/// <summary>
		/// Create and return a copy from the provided game object as a child of the provided transform.
		/// </summary>
		public static GameObject CreateAsChild(this GameObject original, Transform parent)
		{
			var go = (GameObject)Object.Instantiate(original);
			go.name = original.name;
			go.transform.parent = parent;
            go.SetActive(true);
			go.transform.localPosition = Vector3.zero;
			go.transform.localRotation = Quaternion.identity;
			go.transform.localScale = Vector3.one;
			return go;
		}
	}
}
