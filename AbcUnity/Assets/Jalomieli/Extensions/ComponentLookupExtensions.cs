using UnityEngine;
using System;

namespace Jalomieli.Extensions
{
	public static class ComponentLookupExtensions
	{
		/// <summary>
		/// Gets a component from a game object.
		/// Throws an exception if the component is not found.
		/// </summary>
		public static T DemandComponent<T>(this GameObject go) 
			where T : Component
		{
			var component = go.GetComponent<T>();
			if (component == null)
			{
				var msg = string.Format(
					"Demanded component {0} in {1} but found none.", 
					typeof(T),
					go
				);
				throw new ComponentLookupException(msg);
			}
			return component;
		}
		
		/// <summary>
		/// Gets a component from children of a game object.
		/// Throws an exception if the component is not found.
		/// </summary>
		public static T DemandComponentInChildren<T>(this GameObject go) 
			where T : Component
		{
			var component = go.GetComponentInChildren<T>();
			if (component == null)
			{
				var msg = string.Format(
					"Demanded component {0} in children of {1} but found none.", 
					typeof(T),
					go
				);
				throw new ComponentLookupException(msg);
			}
			return component;
		}
		
		/// <summary>
		/// Gets a component from parents of a game object.
		/// Throws an exception if the component is not found.
		/// </summary>
		public static T DemandComponentInParent<T>(this GameObject go) 
			where T : Component
		{
			var component = go.GetComponentInParent<T>();
			if (component == null)
			{
				var msg = string.Format(
					"Demanded component {0} in parents of {1} but found none.", 
					typeof(T),
					go
				);
				throw new ComponentLookupException(msg);
			}
			return component;
		}
	}
}
