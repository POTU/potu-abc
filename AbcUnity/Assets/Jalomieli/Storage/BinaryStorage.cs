using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Jalomieli.Debug;

namespace Jalomieli.Storage
{
	public class BinaryStorage 
	{
		/// <summary>
		/// Does given storage file exist?
		/// </summary>
		/// <param name="path">Path.</param>
		public static bool Exists(string path) 
		{
			var fullPath = Application.persistentDataPath + "/" + path;
			return (File.Exists(fullPath));
		}
	
		/// <summary>
		/// Saves given serializable object to given storage file path.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="serializiableObject">Serializiable object.</param>
		public static void Save(string path, object serializiableObject)
		{
			var bf = new BinaryFormatter();
			var fullPath = Application.persistentDataPath + "/" + path;
			var file = File.Create(fullPath);
			bf.Serialize(file, serializiableObject);
			file.Close();
		}
		
		/// <summary>
		/// Tries to load given serializable object from given storage path.
		/// Logs all failures but doesn't throw exceptions.
		/// </summary>
		/// <returns><c>true</c>, if load was success, <c>false</c> otherwise.</returns>
		/// <param name="path">Path.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static bool TryLoad<T>(string path, out T data) where T : new()
		{
			try 
			{
				data = BinaryStorage.Load<T>(path);
				return true;
			}
			catch (Exception e)
			{
				Log.Warning(e.Message);
				data = default(T);
				return false;
			}
		}
		
		/// <summary>
		/// Load a serializable object from specified storage path.
		/// Throws exceptions on all failures.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <typeparam name="T">Seriliziable class to be casted.</typeparam>
		public static T Load<T>(string path) where T : new()
		{
			var fullPath = Application.persistentDataPath + "/" + path;
			if (!File.Exists(fullPath)) {
				var msg = string.Format(
					"Couldn't find {0} in path {1}.", 
					typeof(T),
					path
				);
				throw new FileNotFoundException(msg);
			}
			
			var bf = new BinaryFormatter();
			var file = File.Open(fullPath, FileMode.Open);
			
			try
			{
				T data = (T)bf.Deserialize(file);
				return data;
			}
			catch (InvalidCastException)
			{
				var msg = string.Format(
					"Couldn't convert data in path {0} to {1}.", 
					path,
					typeof(T)
				);
				throw new InvalidDataException(msg);
			}
			finally 
			{
				file.Close();
			}
		}
	}
}