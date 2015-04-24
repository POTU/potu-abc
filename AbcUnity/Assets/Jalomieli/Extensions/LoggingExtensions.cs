using UnityEngine;
using Jalomieli.Debug;

namespace Jalomieli.Extensions
{
	public static class LoggingExtensions
	{
		public static void LogInfo(this MonoBehaviour mb, object message)
		{
			Log.Info(message, mb);
		}
		public static void LogWarning(this MonoBehaviour mb, object message)
		{
			Log.Warning(message, mb);
		}
		public static void LogError(this MonoBehaviour mb, object message)
		{
			Log.Error(message, mb);
		}
	}
}
