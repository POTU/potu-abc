using UnityEngine;

namespace Jalomieli.Loader
{
	public class Loader 
	{
		
		public static GameObject GetPrefab(string path) 
		{
			return Loader.Get<GameObject>(path);
		}
		
		private static T Get<T>(string path) where T : Object
		{
			T resource = (Resources.Load(path) as T);
			if (resource == null)
			{
				var msg = string.Format(
					"Couldn't find {0} in path {1}.", 
					typeof(T),
					path
				);
				throw new LoaderException(msg);
			}
			return resource;
		}
		
	}
}